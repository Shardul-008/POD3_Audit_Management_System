using AuditManagementPortalClientMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Providers
{
    public interface ISeverityService
    {
        public AuditResponse GetResponse(AuditRequest auditRequest, string token);
        public void StoreResponse(StoreAuditResponse auditResponse);
    }
}
