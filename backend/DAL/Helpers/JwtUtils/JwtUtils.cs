using DAL.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helpers.JwtUtils
{
    public class JwtUtils : IJwtUtils
    {
        public readonly AppSettings _appSettings;

        public JwtUtils(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            Debug.WriteLine("tokenul este");
            Debug.WriteLine(_appSettings.JwtToken);
            var appPrivateKey = Encoding.ASCII.GetBytes("catacatacatacatacatacatacatacatacata");

            var tokenDesriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(appPrivateKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDesriptor);
            Debug.WriteLine("token");
            Debug.WriteLine(token)
;           return tokenHandler.WriteToken(token);
        }

        public Guid ValidateJwtToken(string token)
        {
            Debug.WriteLine(token);
            if (token == null)
            {
                return Guid.Empty;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var appPrivateKey = Encoding.ASCII.GetBytes("catacatacatacatacatacatacatacatacata");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(appPrivateKey),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero,
            };
           
            try
            {
                Debug.WriteLine("a aj1");
                Debug.WriteLine(token);
                tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                Debug.WriteLine("a ajuns aici1");
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = new Guid(jwtToken.Claims.FirstOrDefault(x => x.Type == "id").Value);
                Debug.WriteLine("a ajuns aici2");
                return userId;
            }
            catch (SecurityTokenInvalidIssuerException e)
            {   
                Debug.WriteLine(e.Message);
                Debug.WriteLine("a ajuns aici3");
                return Guid.Empty;
            }
        }
    }
}
