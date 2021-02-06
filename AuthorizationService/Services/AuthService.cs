using AuthorizationService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Service
{
    public class AuthService : IAuthService
    {
        private IAuthRepo authRepo;
        public readonly log4net.ILog log4netval = log4net.LogManager.GetLogger(typeof(AuthService));
        public AuthService(IAuthRepo authRepo)
        {
            this.authRepo = authRepo;
        }
        public string GetJsonWebToken()
        {
            log4netval.Info(" GetJsonWebToken method of AuthService Called ");
            string Token = authRepo.GenerateJWT();
            return Token;
        }
    }
}
