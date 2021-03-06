// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace NuGetGallery {
    public partial class ApiController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ApiController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult CreatePackage() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.CreatePackage);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult DeletePackage() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.DeletePackage);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult PublishPackage() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.PublishPackage);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ApiController Actions { get { return MVC.Api; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Api";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string CreatePackage = "PushPackageApi";
            public readonly string DeletePackage = "DeletePackageApi";
            public readonly string PublishPackage = "PublishPackageApi";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_ApiController: NuGetGallery.ApiController {
        public T4MVC_ApiController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult CreatePackage(System.Guid apiKey) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.CreatePackage);
            callInfo.RouteValueDictionary.Add("apiKey", apiKey);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult DeletePackage(System.Guid apiKey, string id, string version) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.DeletePackage);
            callInfo.RouteValueDictionary.Add("apiKey", apiKey);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("version", version);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult PublishPackage(System.Guid key, string id, string version) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.PublishPackage);
            callInfo.RouteValueDictionary.Add("key", key);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("version", version);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
