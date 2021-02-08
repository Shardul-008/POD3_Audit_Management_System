using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Services
{
    public interface ILoginService
    {
        public string GetToken();
    }
}
