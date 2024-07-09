﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ReservaTurnos.Core.Application.Contracts.Persistence;
using ReservaTurnos.Core.Application.Exceptions;
using ReservaTurnos.Core.Application.Jwt;
using ReservaTurnos.Core.Domain.DTO;
using ReservaTurnos.Core.Domain.Models;
using System.Security.Claims;
using System.Text;

namespace ReservaTurnos.Core.Application.Features.Auth
{
    public class AuthService
    {
        private IUserRepository _UserRepository;
        public IConfiguration _configuration;
        private string _KeyEncriptDecript = string.Empty;

        public AuthService(IConfiguration configuration, IUserRepository userRepository)
        {
            _UserRepository = userRepository;
            _configuration = configuration;
            _KeyEncriptDecript = _configuration["KeyEncriptDecript"]; 
        }

        public async Task<Token> Login(AuthRequest authRequest)
        {
            var userByEmail = await _UserRepository.FindByEmailAsync(authRequest.email);
            if (userByEmail == null)
                throw new NotFoundException(nameof(User), authRequest.email);

            if (Commons.EncryptDecript.Decript(userByEmail.contrasena, _KeyEncriptDecript) != authRequest.contrasena)
                throw new BadRequestException("Las credenciales son incorrectas");

            var infoUser = await GenerateInfoUser(userByEmail);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userByEmail.Id.ToString()),
                new Claim("infoUser", JsonConvert.SerializeObject(infoUser))
            });

            var tokenGenerator = new TokenGenerator();
            var tokenResult = await tokenGenerator.GenerateToken(_configuration, claimsIdentity, userByEmail.email);

            return tokenResult.token;
        }

        public async Task<Token> Register(RegistrationRequest registrationRequest)
        {
            var userByEmail = await _UserRepository.FindByEmailAsync(registrationRequest.email);
            if (userByEmail != null)
                throw new Exception("El email ya fue tomado por otra cuenta");

            User user = new User();
            user.contrasena = Commons.EncryptDecript.Encript(registrationRequest.contrasena, _KeyEncriptDecript);
            user.email = registrationRequest.email;
            user.nombre_usuario = registrationRequest.nombre_usuario;
            user.id_rol = registrationRequest.id_rol;

            await _UserRepository.AddEntityAsync(user);

            var infoUser = await GenerateInfoUser(user);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim("infoUser", JsonConvert.SerializeObject(infoUser))
            });

            var tokenGenerator = new TokenGenerator();
            var tokenResult = await tokenGenerator.GenerateToken(_configuration, claimsIdentity, user.email);
            
            return tokenResult.token;

        }

        private async Task<InfoUser> GenerateInfoUser(User user)
        {
            InfoUser infoUser = new InfoUser();
            infoUser.idUser = user.Id;
            infoUser.nombre_usuario = user.nombre_usuario;
            infoUser.email = user.email;
            infoUser.id_rol = user.id_rol;

            return infoUser;
        }
    }
}