using ItinerarioSNC.Infra.CrossCutting.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ItinerarioSNC.Service.Services
{
    public class TokenService : ITokenJWTService
    {
        private readonly IConfiguration configuration;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string GerarToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("JWTToken:Secret").Value);
            var SimetricKey = new SymmetricSecurityKey(key);
            var token = new JwtSecurityToken(null, null, null, DateTime.Now, DateTime.Now.AddSeconds(1), 
                    new SigningCredentials(SimetricKey, SecurityAlgorithms.HmacSha256));

            
            return tokenHandler.WriteToken(token);
        }
    }
}
