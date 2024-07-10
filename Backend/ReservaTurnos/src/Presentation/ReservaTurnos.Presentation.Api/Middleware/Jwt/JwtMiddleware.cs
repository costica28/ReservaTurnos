using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ReservaTurnos.Core.Domain.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReservaTurnos.Presentation.Api.Middleware.Jwt
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext content)
        {
            var token = content.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await AttachUserToContextAsync(content, token);

            await _next(content);
        }

        public async Task AttachUserToContextAsync(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

                var tokenArray = jwtToken.Claims.ToArray();
                var tokenClaims = tokenArray[1];
                var tokenValue = tokenClaims.Value;

                
                User user = JsonConvert.DeserializeObject<User>(tokenValue);
                context.Items["User"] = user;
                if(context.User != null)
                {
                    var customPrincipal = new CustomPrincipal(user.email);
                    var identity = new ClaimsPrincipal(customPrincipal);
                    context.User = identity;
                }
            }
            catch (Exception ex)
            {

               
            }
        }

    }
}
