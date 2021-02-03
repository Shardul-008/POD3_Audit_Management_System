using AuditManagementPortalClientMVC.Models;
using AuditManagementPortalClientMVC.Models.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Repository
{
    public class SeverityRepo : ISeverityRepo
    {
        private AuditDbContext auditDbContext;
        public SeverityRepo(AuditDbContext auditDbContext)
        {
            this.auditDbContext = auditDbContext;
        }
        public AuditResponse GetResponse(AuditRequest auditRequest, string token)
        {
            AuditResponse auditResponse = new AuditResponse();

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback +=
                (sender, certificate, chain, errors) =>
                {
                    return true;
                };

            using (var httpClient = new HttpClient(handler))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                StringContent content = new StringContent(JsonConvert.SerializeObject(auditRequest), Encoding.UTF8, "application/json");

                HttpResponseMessage response = httpClient.PostAsync("https://localhost:44303/api/AuditSeverity", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    auditResponse = JsonConvert.DeserializeObject<AuditResponse>(result);
                }

            }
            return auditResponse;
        }
        public void StoreResponse(StoreAuditResponse auditResponse)
        {
            auditDbContext.storeAuditResponses.Add(auditResponse);
            auditDbContext.SaveChanges();
        }

    }
}
