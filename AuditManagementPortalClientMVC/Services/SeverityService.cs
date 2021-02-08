using AuditManagementPortalClientMVC.Models;
using AuditManagementPortalClientMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Services
{
    public class SeverityService : ISeverityService
    {
        private  ISeverityRepo severityRepo;

        public SeverityService(ISeverityRepo severityRepo)
        {
            this.severityRepo = severityRepo;
        }
        public AuditResponse GetResponse(AuditRequest auditRequest, string token)
        {
            AuditResponse auditResponse = severityRepo.GetResponse(auditRequest, token);
            return auditResponse;
            //throw new NotImplementedException();
        }
        public void StoreResponse(StoreAuditResponse auditResponse)
        {
            severityRepo.StoreResponse(auditResponse);
        }


    }
}
