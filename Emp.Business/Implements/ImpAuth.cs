using Emp.Business.Interfaces;
using Emp.Core;
using Emp.Core.General;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Business.Implements
{
    public class ImpAuth : IAuth
    {
        private readonly AppSettings _appSettings;



        public ImpAuth(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public Auth Autorizar()
        {
            Auth au = new Auth();
            au.Email = "edson.madrid@gmail.com";
            au.Password = "Eam041209";
            au.Token = GetToken(au);


            return au;
        }

        private string GetToken(Auth usuario)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var llave = Encoding.ASCII.GetBytes(_appSettings.secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                         new Claim[]
                         {
                         new Claim(ClaimTypes.NameIdentifier, usuario.Email.ToString()),
                         new Claim(ClaimTypes.Email, usuario.Email)
                         }
                    ),
                    Expires = DateTime.UtcNow.AddDays(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
    }
}
