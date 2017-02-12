using Amayer.Info.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amayer.Info.Areas.Admin.Controllers
{
    [Authorization]
    public class BaseController : Controller
    {

        //protected new CurrentUser User { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (filterContext.HttpContext.Items.Contains("CurrentUser"))
            //{
            //    User = filterContext.HttpContext.Items["CurrentUser"] as CurrentUser;
            //    ViewBag.User = User;
            //}
            //if (filterContext.HttpContext.Response.StatusCode == 403)
            //{
            //    filterContext.Result = RedirectToAction("denied", "error");
            //}
            base.OnActionExecuting(filterContext);
        }
        /// <summary>
        /// action之后
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Items.Contains("Menus"))
            {
                ViewBag.Menus = filterContext.HttpContext.Items["Menus"];
            }
            //var db = new RunToDbContext();
            //// errors
            //if (filterContext.Exception != null)
            //{
            //    var error = new ErrorRecord();
            //    error.Message = filterContext.Exception.Message;
            //    error.Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //    error.Action = filterContext.ActionDescriptor.ActionName;
            //    error.Source = filterContext.Exception.Source;
            //    error.StackTrace = filterContext.Exception.StackTrace;
            //    error.Status = 1;
            //    error.Member = User == null ? "未知用户" : User.RealName;
            //    error.CreateTime = DateTime.Now;
            //    db.ErrorRecord.Add(error);

            //}
            //ViewBag.Messages = db.Guestbook.Where(m => m.Status == 1 && !m.IsRead).OrderByDescending(m => m.CreateTime).Take(5).ToList();
            //db.Dispose();
            base.OnActionExecuted(filterContext);
        }
    }
}