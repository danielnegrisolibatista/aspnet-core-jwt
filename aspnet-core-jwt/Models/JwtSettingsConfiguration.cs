using Microsoft.IdentityModel.Tokens;
using System;

namespace aspnet_core_jwt.Models
{
    public class JwtSettingsConfiguration
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; } // quem emite o token JWT
        public string Audience { get; set; } // aplicações que podem usar o token JWT
        public string SigningKey { get; set; }
        public int ValidForMinutes { get; set; }
        public DateTime IssuedAt => DateTime.UtcNow;  // data e hora em que o token foi emitido
        public DateTime? NotBefore => IssuedAt;
        public DateTime Expires => IssuedAt.AddMinutes(ValidForMinutes); // data e hora em que o token irá expirar
    }
}
