using Amayer.Info.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amayer.Info.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            AdminHomeViewModel model = new AdminHomeViewModel();
            model.ServerMachineName = HttpContext.Server.MachineName;
            model.ServerIp = HttpContext.Request.ServerVariables["LOCAL_ADDR"];
            model.ServerPort = HttpContext.Request.ServerVariables["SERVER_PORT"];
            model.ServerSystem = Environment.OSVersion.ToString();
            model.ServerSoftware = HttpContext.Request.ServerVariables["SERVER_SOFTWARE"];
            model.ServerName = HttpContext.Request.ServerVariables["SERVER_NAME"];
            model.FrameworkVersion = Environment.Version.Major + "." + Environment.Version.Minor + "." + Environment.Version.Build + "." + Environment.Version.Revision;

            model.CpuType = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            model.CpuCount = Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");

            model.ClientIp = HttpContext.Request.UserHostAddress;
            model.UserAgent = HttpContext.Request.ServerVariables["HTTP_USER_AGENT"];
            model.Browser = HttpContext.Request.Browser.Browser + " " + HttpContext.Request.Browser.Version;
            return View(model);
        }
    }
}