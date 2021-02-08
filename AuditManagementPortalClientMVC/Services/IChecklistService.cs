using AuditManagementPortalClientMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Services
{
    public interface IChecklistService
    {
        public List<CQuestions> ProvideChecklist(string audittype, string token);
    }
}
