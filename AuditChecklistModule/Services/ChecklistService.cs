using AuditChecklistModule.Models;
using AuditChecklistModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistModule.Service
{
    public class ChecklistService : IChecklistService
    {
        private IChecklistRepo checklistRepoObj;
        private log4net.ILog log4netval;
        public ChecklistService(IChecklistRepo checklistRepoObj)
        {
            this.checklistRepoObj = checklistRepoObj;
            log4netval = log4net.LogManager.GetLogger(typeof(ChecklistService));
        }
        List<Questions> ListOfQuestions = new List<Questions>();

        public List<Questions> GetQuestionList(string auditType)
        {
            log4netval.Info(" Http GET request called" + nameof(ChecklistService));
            ListOfQuestions = checklistRepoObj.GetQuestions(auditType);
            return ListOfQuestions;
        }
    }
}
