using AuditManagementPortalClientMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Providers
{
    public class LoginService : ILoginService
    {
        private  ILoginRepo loginRepo;

        public LoginService(ILoginRepo loginRepo)
        {
            this.loginRepo = loginRepo;
        }
        public string GetToken()
        {
            string t = loginRepo.GetToken().Result;
            return t;
            //throw new NotImplementedException();
        }
    }
}
