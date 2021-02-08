using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AuditManagementPortalClientMVC.Models;
using AuditManagementPortalClientMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AuditManagementPortalClientMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly log4net.ILog log4netval;
        private ISeverityService severityService;
        private ILoginService loginService;
        private IUserService userService;
        private IChecklistService checklistService;

        public HomeController(ISeverityService severityService ,ILoginService loginService , IUserService userService, IChecklistService checklistService)
        {
            
            log4netval = log4net.LogManager.GetLogger(typeof(HomeController));
            this.severityService = severityService;
            this.loginService = loginService;
            this.userService = userService;
            this.checklistService = checklistService;
        }
        
        [HttpGet]
        public IActionResult SignOut() 
        {
            log4netval.Info(" Get request for signout in " + nameof(HomeController));
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            log4netval.Info(" Get request for Login in " + nameof(HomeController));
            try
            {
                var t = HttpContext.Session.GetString("token").ToString();

                if (t == "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                log4netval.Error(" Exception here" + e.Message + " " + nameof(HomeController));
                HttpContext.Session.Clear();
                ViewBag.ErrorMessage = "";
                return View();
            }
            return RedirectToAction("AuditType", "Home");
        }


        [HttpPost]
        public IActionResult Login(User user)
        {
            log4netval.Info(" Post request for Login in " + nameof(HomeController));
            bool value = userService.CheckUser(user);
            if (value == true) 
            {
                string token = loginService.GetToken();
                var t = token;

                if (t != "")
                {
                    HttpContext.Session.Clear();
                    HttpContext.Session.SetString("uid", user.Name);
                    HttpContext.Session.SetString("token", t);
                    return RedirectToAction("AuditType", "Home");

                }

                
            }
            ViewBag.ErrorMessage = "• Invalid Username Or Password";
            return View();
        }

        [HttpGet]
        public IActionResult AuditType()
        {
            log4netval.Info(" Get request for AuditType in " + nameof(HomeController));
            try
            {
                var t = HttpContext.Session.GetString("token").ToString();

                if (t == "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                log4netval.Error(" Exception here" + e.Message + " " + nameof(HomeController));
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Home");
            }
            ViewBag.User = HttpContext.Session.GetString("uid");
            
            return View();
        }

        [HttpGet]
        public IActionResult Checklist()
        {
            log4netval.Info(" Get request for Checklist in " + nameof(HomeController));
            try
            {
                HttpContext.Session.Remove("audittype");
                return RedirectToAction("Login", "Home");
            }
            catch (Exception ex) 
            {
                log4netval.Error(" Exception here" + ex.Message + " " + nameof(HomeController));
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public IActionResult Checklist(string audittype) 
        {
            log4netval.Info(" Post request for Checklist in " + nameof(HomeController));
            if (audittype == "Internal") 
            {

                List<CQuestions> listOfQuestions = checklistService.ProvideChecklist("Internal",HttpContext.Session.GetString("token"));
                
                //HttpContext.Response.Headers.Add("tokenRes", HttpContext.Session.GetString("token"));
                
                HttpContext.Session.SetString("audittype", audittype);

                return View(listOfQuestions);
            }
            if (audittype == "SOX") 
            {
             
                List<CQuestions> listOfQuestions = checklistService.ProvideChecklist("SOX", HttpContext.Session.GetString("token"));
                
                HttpContext.Session.SetString("audittype", audittype);
                return View(listOfQuestions);
            }
           
            return RedirectToAction("AuditType", "Home");
        }
        
        [HttpGet]
        public IActionResult Severity() 
        {
            log4netval.Info(" Get request for Severity in " + nameof(HomeController));

            try
            {
                HttpContext.Session.Remove("audittype");
                return RedirectToAction("Login", "Home");
            }
            catch (Exception ex)
            {
                log4netval.Error(" Exception here" + ex.Message + " " + nameof(HomeController));
            }
            return RedirectToAction("Login", "Home");
        }

       [HttpPost]
        public IActionResult Severity(bool q1 , bool q2, bool q3, bool q4, bool q5,
            string pnm, string mnm, string onm, DateTime dtee)
        {
            log4netval.Info(" Post request for Severity in " + nameof(HomeController));

            string dtees = dtee.ToString();
            string aType = HttpContext.Session.GetString("audittype").ToString();
            AuditRequest auditRequest = new AuditRequest();
            Questions qq = new Questions()
            {
                Question1 = q1,
                Question2 = q2,
                Question3 = q3,
                Question4 = q4,
                Question5 = q5
            };
            auditRequest.ProjectName = pnm;
            auditRequest.ProjectManagerName = mnm;
            auditRequest.ApplicationOwnerName = onm;
            auditRequest.Auditdetails = new AuditDetail() { Type = aType, Date = dtees, questions = qq };
            
            AuditResponse auditResponse = severityService.GetResponse(auditRequest, HttpContext.Session.GetString("token"));


            StoreAuditResponse storeAudit = new StoreAuditResponse()
            {
                ProjectName = pnm,
                ProjectManagerName = mnm,
                ApplicationOwnerName = onm,
                AuditType = aType,
                AuditDate = dtees,
                AuditId = auditResponse.AuditId,
                ProjectExecutionStatus = auditResponse.ProjectExexutionStatus,
                RemedialActionDuration = auditResponse.RemedialActionDuration
            };
            try
            {
                severityService.StoreResponse(storeAudit);
            }
            catch (Exception e)
            {
                log4netval.Error(" Exception here" + e.Message + " " + nameof(HomeController));
            }

            return View(auditResponse);
        }




    }
}
