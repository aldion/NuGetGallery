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

namespace NuGetGallery.Views.Users
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Users/ChangePassword.cshtml")]
    public class ChangePassword : System.Web.Mvc.WebViewPage<PasswordChangeViewModel>
    {
        public ChangePassword()
        {
        }
        public override void Execute()
        {


            
            #line 2 "..\..\Views\Users\ChangePassword.cshtml"
  
    ViewBag.Title = "Change Password";


            
            #line default
            #line hidden
WriteLiteral("             \r\n<h1 class=\"page-heading\">Change Password</h1>\r\n\r\n");


            
            #line 8 "..\..\Views\Users\ChangePassword.cshtml"
 using (Html.BeginForm()) {

            
            #line default
            #line hidden
WriteLiteral("    <fieldset class=\"form\">\r\n        <legend>Register Form</legend>\r\n\r\n        ");


            
            #line 12 "..\..\Views\Users\ChangePassword.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n        ");


            
            #line 13 "..\..\Views\Users\ChangePassword.cshtml"
   Write(Html.ValidationSummary(true));

            
            #line default
            #line hidden
WriteLiteral("\r\n              \r\n        ");


            
            #line 15 "..\..\Views\Users\ChangePassword.cshtml"
   Write(Html.EditorForModel());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n        <img src=\"");


            
            #line 17 "..\..\Views\Users\ChangePassword.cshtml"
             Write(Url.Content("~/content/images/required.png"));

            
            #line default
            #line hidden
WriteLiteral("\" alt=\"Blue border on left means required.\" />\r\n\r\n        <input type=\"submit\" va" +
"lue=\"Save\" title=\"Change password\" />\r\n        <a class=\"cancel\" href=\"");


            
            #line 20 "..\..\Views\Users\ChangePassword.cshtml"
                           Write(Url.Action("Account"));

            
            #line default
            #line hidden
WriteLiteral("\" title=\"Cancel Changes and go back.\">Cancel</a>\r\n    </fieldset>\r\n");


            
            #line 22 "..\..\Views\Users\ChangePassword.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");


DefineSection("BottomScripts", () => {

WriteLiteral("\r\n    <script src=\"");


            
            #line 25 "..\..\Views\Users\ChangePassword.cshtml"
            Write(Url.Content("~/Scripts/jquery.validate.min.js"));

            
            #line default
            #line hidden
WriteLiteral("\" type=\"text/javascript\"></script>\r\n    <script src=\"");


            
            #line 26 "..\..\Views\Users\ChangePassword.cshtml"
            Write(Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js"));

            
            #line default
            #line hidden
WriteLiteral("\" type=\"text/javascript\"></script>\r\n");


});


        }
    }
}
#pragma warning restore 1591
