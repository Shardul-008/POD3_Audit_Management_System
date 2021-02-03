using AuditChecklistModule.Models;
using AuditChecklistModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistModule.Providers
{
    public class ChecklistService : IChecklistService
    {
        IChecklistRepo checklistRepoObj;
        public ChecklistService(IChecklistRepo checklistRepoObj)
        {
            this.checklistRepoObj = checklistRepoObj;
        }
        List<Questions> ListOfQuestions = new List<Questions>();

        public List<Questions> GetQuestionList(string auditType)
        {
            ListOfQuestions = checklistRepoObj.GetQuestions(auditType);
            return ListOfQuestions;
        }
    }
}
