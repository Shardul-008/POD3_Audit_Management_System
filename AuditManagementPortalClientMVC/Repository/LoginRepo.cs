using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Repository
{
    public class LoginRepo : ILoginRepo
    {
        public async Task<string> GetToken()
        {
            string t = "";
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback +=
                (sender, certificate, chain, errors) =>
                {
                    return true;
                };
            using (var httpClient = new HttpClient(handler))
            {

                using (var response = await httpClient.GetAsync("https://localhost:44396/api/token"))
                {
                    string token = await response.Content.ReadAsStringAsync();
                    t = token;
                }
            }
            return t;
        }
    }
}
