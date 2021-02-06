using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditChecklistModule.Models;
using AuditChecklistModule.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditChecklistModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuditChecklistController : ControllerBase
    {

        private IChecklistService checklistServiceObj;
        private readonly log4net.ILog log4netval;

        public AuditChecklistController(IChecklistService checklistServiceObj)
        {
            log4netval = log4net.LogManager.GetLogger(typeof(AuditChecklistController));
            this.checklistServiceObj = checklistServiceObj;
        }

        [HttpGet]
        public IActionResult GetAuditCheckListQuestions([FromBody]string auditType)
        {
            log4netval.Info("AuditChecklistController Http GET request called" + nameof(AuditChecklistController));

            if (string.IsNullOrEmpty(auditType))
                return BadRequest("No Input");
            else if ((auditType != "Internal") && (auditType != "SOX"))
                return Ok("Wrong Input");
            else
            {
                try
                {
                    List<Questions> list = checklistServiceObj.GetQuestionList(auditType);
                    return Ok(list);
                }
                catch (Exception e)
                {
                    log4netval.Error("Exception " + e.Message + nameof(AuditChecklistController));

                    return StatusCode(500);
                }
            }
        }
    }
}
