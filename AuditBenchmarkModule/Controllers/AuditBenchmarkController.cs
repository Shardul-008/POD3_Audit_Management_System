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
        private IBenchmarkService objService;
        public AuditBenchmarkController(IBenchmarkService objService)
        {
            this.objService = objService;
        }


        [HttpGet]
        public IActionResult GetAuditBenchmark()
        {
            List<AuditBenchmark> listOfBenchmark = new List<AuditBenchmark>();
            try
            {
                listOfBenchmark = objService.GetBenchmark();
                return Ok(listOfBenchmark);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
