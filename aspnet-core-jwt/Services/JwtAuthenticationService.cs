using aspnet_core_jwt.Models;
using aspnet_core_jwt.Services.Interface;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;



namespace aspnet_core_jwt.Services
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly JwtSettingsConfiguration _jwtSettingsConfiguration;
        
        public JwtAuthenticationService(JwtSettingsConfiguration jwtSettingsConfiguration)
        {
            _jwtSettingsConfiguration = jwtSettingsConfiguration;
        }
        public object Authentication(UserLogged userLogged)
        {
            var identity = GetClaimsIdentity(userLogged);
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtSettingsConfiguration.SecretKey);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = identity,
                Issuer = _jwtSettingsConfiguration.Issuer,
                Audience = _jwtSettingsConfiguration.Audience,
                IssuedAt = _jwtSettingsConfiguration.IssuedAt,
                NotBefore = _jwtSettingsConfiguration.NotBefore,
                Expires = _jwtSettingsConfiguration.Expires,
                SigningCredentials = credentials
            });

            var jwtToken = handler.WriteToken(securityToken);

            return new
            {
                access_token = jwtToken,
                token_type = "bearer",
                expires_in = (int)_jwtSettingsConfiguration.ValidForMinutes
            };
        }
        private static ClaimsIdentity GetClaimsIdentity(UserLogged userLogged)
        {
            return new ClaimsIdentity
            (
                new GenericIdentity(userLogged.Email),
                new[] 
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userLogged.Name),
                    new Claim(JwtRegisteredClaimNames.Email, userLogged.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                    new Claim(ClaimTypes.Name, userLogged.Name),
                    new Claim(ClaimTypes.Role, userLogged.Role),
                    new Claim("UserData", JsonSerializer.Serialize(userLogged)),
                }
            );
        }
    }
}
