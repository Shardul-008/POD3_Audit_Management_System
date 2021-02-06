using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditBenchmarkModule.Models;
using AuditBenchmarkModule.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditBenchmarkModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuditBenchmarkController : ControllerBase
    {
        private readonly log4net.ILog log4netval;
        private IBenchmarkService objService;
        public AuditBenchmarkController(IBenchmarkService objService)
        {
            log4netval = log4net.LogManager.GetLogger(typeof(AuditBenchmarkController));
            this.objService = objService;
        }


        [HttpGet]
        public IActionResult GetAuditBenchmark()
        {
            List<AuditBenchmark> listOfBenchmark = new List<AuditBenchmark>();
            log4netval.Info(" Http GET request " + nameof(AuditBenchmarkController));
            try
            {
                listOfBenchmark = objService.GetBenchmark();
                return Ok(listOfBenchmark);
            }
            catch (Exception e)
            {
                log4netval.Error(" Exception here" + e.Message + " " + nameof(AuditBenchmarkController));
                return StatusCode(500);
            }
        }
    }
}
