using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReservaTurnos.Core.Domain.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReservaTurnos.Core.Application.Jwt
{
    public class TokenGenerator
    {
        public async Task<Authorization> GenerateToken(IConfiguration configuration, ClaimsIdentity claimsIdentity, string email)
        {
            var resultToken = GenerateTokenJwt(configuration, claimsIdentity);

            var expireTime = configuration["JwtToken:ExpireTime"];

            var authorization = new Authorization();
            authorization.id = 0;
            authorization.email = email;
            authorization.token = new Token()
            {
                access_token = resultToken,
                token_type = "bearer",
                expires_in = Convert.ToInt32(expireTime)
            };

            return authorization;
        }

        public string GenerateTokenJwt(IConfiguration configuration, ClaimsIdentity claimsIdentity)
        {
            var secretKey = configuration["JwtToken:SecretKey"];
            var audienceToken = configuration["JwtToken:Audience"];
            var issuerToken = configuration["JwtToken:Issuer"];
            var expireTime = configuration["JwtToken:ExpireTime"];

            var symmertricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(symmertricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials

                );

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;

        }
    }
}
