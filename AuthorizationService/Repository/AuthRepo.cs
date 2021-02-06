using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationService.Repository
{
    public class AuthRepo : IAuthRepo
    {
        private IConfiguration Config;
        public readonly log4net.ILog log4netval = log4net.LogManager.GetLogger(typeof(AuthRepo));
        public AuthRepo(IConfiguration Config)
        {
            this.Config = Config;
        }
        public string GenerateJWT()
        {
            log4netval.Info(" GenerateJWT method of AuthRepo Called ");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(Config["Jwt:Issuer"],
              Config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
