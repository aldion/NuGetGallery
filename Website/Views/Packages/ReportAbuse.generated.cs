﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.237
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuGetGallery.Views.Packages
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Microsoft.Web.Helpers;
    using NuGetGallery;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Packages/ReportAbuse.cshtml")]
    public class ReportAbuse : System.Web.Mvc.WebViewPage<ReportAbuseViewModel>
    {
        public ReportAbuse()
        {
        }
        public override void Execute()
        {


            
            #line 2 "..\..\Views\Packages\ReportAbuse.cshtml"
  
    ViewBag.Tab = "Packages";


            
            #line default
            #line hidden
WriteLiteral("\r\n<h1 class=\"page-heading\">Report Abuse</h1>\r\n\r\n<p class=\"message\">\r\n    Importan" +
"t: This form is for reporting <em>abusive</em> packages such as \r\n    packages c" +
"ontaining <em>malicious code</em> or spam. If \"");


            
            #line 10 "..\..\Views\Packages\ReportAbuse.cshtml"
                                                        Write(Model.PackageId);

            
            #line default
            #line hidden
WriteLiteral("\" simply doesn\'t \r\n    appear to work or work correctly, please \r\n    <a href=\"");


            
            #line 12 "..\..\Views\Packages\ReportAbuse.cshtml"
        Write(Url.Action(MVC.Packages.ContactOwners(Model.PackageId)));

            
            #line default
            #line hidden
WriteLiteral("\" title=\"contact the owners\">contact the owners of \"");


            
            #line 12 "..\..\Views\Packages\ReportAbuse.cshtml"
                                                                                                                    Write(Model.PackageId);

            
            #line default
            #line hidden
WriteLiteral("\".</a> \r\n</p>                            \r\n\r\n<p>Please provide a detailed abuse r" +
"eport. Include exactly what the package did.</p>\r\n\r\n");


            
            #line 17 "..\..\Views\Packages\ReportAbuse.cshtml"
 using (Html.BeginForm()) {

            
            #line default
            #line hidden
WriteLiteral("    <fieldset class=\"form\">\r\n        <legend>Report Abuse</legend>\r\n        ");


            
            #line 20 "..\..\Views\Packages\ReportAbuse.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div class=\"form-field\">\r\n");


            
            #line 22 "..\..\Views\Packages\ReportAbuse.cshtml"
         if (!Model.ConfirmedUser) {
            
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Packages\ReportAbuse.cshtml"
       Write(Html.LabelFor(m => m.Email));

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Packages\ReportAbuse.cshtml"
                                        
            
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Packages\ReportAbuse.cshtml"
       Write(Html.EditorFor(m => m.Email));

            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Packages\ReportAbuse.cshtml"
                                         

            
            #line default
            #line hidden
WriteLiteral("            <span class=\"field-hint-message\">Provide your email address so we can" +
" follow up with you.</span>\r\n");


            
            #line 26 "..\..\Views\Packages\ReportAbuse.cshtml"
            
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Packages\ReportAbuse.cshtml"
       Write(Html.ValidationMessageFor(m => m.Email));

            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Packages\ReportAbuse.cshtml"
                                                    
        }
        else {

            
            #line default
            #line hidden
WriteLiteral("            <input type=\"hidden\" name=\"Email\" value=\"test@example.com\" />\r\n");


            
            #line 30 "..\..\Views\Packages\ReportAbuse.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n        <div class=\"form-field\">\r\n            ");


            
            #line 33 "..\..\Views\Packages\ReportAbuse.cshtml"
       Write(Html.LabelFor(m => m.Message));

            
            #line default
            #line hidden
WriteLiteral("\r\n            ");


            
            #line 34 "..\..\Views\Packages\ReportAbuse.cshtml"
       Write(Html.TextAreaFor(m => m.Message, 10, 50, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n            ");


            
            #line 35 "..\..\Views\Packages\ReportAbuse.cshtml"
       Write(Html.ValidationMessageFor(m => m.Message));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <input type=\"submit\" value=\"Report\" title=\"Report \'");


            
            #line 37 "..\..\Views\Packages\ReportAbuse.cshtml"
                                                      Write(Model.PackageId);

            
            #line default
            #line hidden
WriteLiteral("\' for abuse\" />\r\n    </fieldset>\r\n");


            
            #line 39 "..\..\Views\Packages\ReportAbuse.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");


DefineSection("BottomScripts", () => {

WriteLiteral("\r\n    <script src=\"");


            
            #line 42 "..\..\Views\Packages\ReportAbuse.cshtml"
            Write(Url.Content("~/Scripts/jquery.validate.min.js"));

            
            #line default
            #line hidden
WriteLiteral("\" type=\"text/javascript\"></script>\r\n    <script src=\"");


            
            #line 43 "..\..\Views\Packages\ReportAbuse.cshtml"
            Write(Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js"));

            
            #line default
            #line hidden
WriteLiteral("\" type=\"text/javascript\"></script>\r\n");


});


        }
    }
}
#pragma warning restore 1591
