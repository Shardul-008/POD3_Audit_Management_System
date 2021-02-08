using AuditManagementPortalClientMVC.Models;
using AuditManagementPortalClientMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Services
{
    public class ChecklistService : IChecklistService
    {
        private  IChecklistRepo checklistRepo;

        public ChecklistService(IChecklistRepo checklistRepo)
        {
            this.checklistRepo = checklistRepo;
        }
        public List<CQuestions> ProvideChecklist(string audittype, string token)
        {
            List<CQuestions> lq = checklistRepo.ProvideChecklist(audittype, token);
            return lq;
        }
    }
}
