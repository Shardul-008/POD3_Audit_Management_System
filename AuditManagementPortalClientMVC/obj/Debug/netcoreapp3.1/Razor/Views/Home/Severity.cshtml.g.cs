#pragma checksum "D:\Audit management\AuditManagement\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a5a8d63cb87db431f16403782c2e3121938c230"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Severity), @"mvc.1.0.view", @"/Views/Home/Severity.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Audit management\AuditManagement\AuditManagementPortalClientMVC\Views\_ViewImports.cshtml"
using AuditManagementPortalClientMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Audit management\AuditManagement\AuditManagementPortalClientMVC\Views\_ViewImports.cshtml"
using AuditManagementPortalClientMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a5a8d63cb87db431f16403782c2e3121938c230", @"/Views/Home/Severity.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d6869f38201b3cd0daebbe0fa6ea487d04170ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Severity : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AuditManagementPortalClientMVC.Models.AuditResponse>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\Audit management\AuditManagement\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
  
    Layout = "_Authenticated";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 7 "D:\Audit management\AuditManagement\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
   ViewData["Title"] = "SeverityResult"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<h1>Result Based On Audit Request</h1>\n\n");
#nullable restore
#line 12 "D:\Audit management\AuditManagement\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
 if (Model.ProjectExexutionStatus == "GREEN")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div style=\" background-color: lawngreen;\">\n        <h1>Audit Id :</h1>\n        <h3>");
#nullable restore
#line 16 "D:\Audit management\AuditManagement\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
       Write(Model.AuditId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\n        <h1>Project Execution Status :</h1>\n        <h3> ");
#nullable restore
#line 18 "D:\Audit management\AuditManagement\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
        Write(Model.ProjectExexutionStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n        <h1>Remedial Action Duration :</h1>\n        <h3> ");
#nullable restore
#line 20 "D:\Audit management\AuditManagement\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
        Write(Model.RemedialActionDuration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n\n    </div>\n");
#nullable restore
#line 23 "D:\Audit management\AuditManagement\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"


}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div style=\" background-color: red; color: white;\">\n        <h1>Audit Id :</h1>\n        <h3>");
#nullable restore
#line 30 "D:\Audit management\AuditManagement\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
       Write(Model.AuditId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\n        <h1>Project Execution Status :</h1>\n        <h3> ");
#nullable restore
#line 32 "D:\Audit management\AuditManagement\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
        Write(Model.ProjectExexutionStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n        <h1>Remedial Action Duration :</h1>\n        <h3> ");
#nullable restore
#line 34 "D:\Audit management\AuditManagement\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
        Write(Model.RemedialActionDuration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n\n    </div>\n");
#nullable restore
#line 37 "D:\Audit management\AuditManagement\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"

}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AuditManagementPortalClientMVC.Models.AuditResponse> Html { get; private set; }
    }
}
#pragma warning restore 1591
