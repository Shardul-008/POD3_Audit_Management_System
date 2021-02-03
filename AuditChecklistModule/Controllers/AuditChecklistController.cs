using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditChecklistModule.Models;
using AuditChecklistModule.Providers;
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
        IChecklistService checklistServiceObj;

        public AuditChecklistController(IChecklistService checklistServiceObj)
        {
            this.checklistServiceObj = checklistServiceObj;
        }

        [HttpGet]
        public IActionResult GetAuditCheckListQuestions([FromBody]string auditType)
        {
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
                    return StatusCode(500);
                }
            }
        }
    }
}
