using AuthorizationService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Providers
{
    public class AuthService : IAuthService
    {
        private IAuthRepo authRepo;
        public AuthService(IAuthRepo authRepo)
        {
            this.authRepo = authRepo;
        }
        public string GetJsonWebToken()
        {
            string Token = authRepo.GenerateJWT();
            return Token;
        }
    }
}
