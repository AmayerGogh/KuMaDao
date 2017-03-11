using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amayer.Info.Controllers
{
    public class BaseController : Controller
    {
       

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);  
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            if (filterContext.HttpContext.Items.Contains("Menus"))
            {
                ViewData.Add("Menus", filterContext.HttpContext.Items["Menus"]);
            }

            // errors
            if (filterContext.Exception != null)
            {  
                //var error = new ErrorRecord();
               // error.Message = filterContext.Exception.Message;
               // error.Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
               // error.Action = filterContext.ActionDescriptor.ActionName;
               // error.Source = filterContext.Exception.Source;
               // error.StackTrace = filterContext.Exception.StackTrace;
               //// error.Status = (int)Enums.Status.正常;
               // error.Member = User == null ? "未知用户" : User.RealName;
               // error.CreateTime = DateTime.Now;
               // db.ErrorRecord.Add(error);
               // db.SaveChanges();
            }

            if (User != null)
               // ViewBag.Messages = MessageBLL.GetExtList(User.Id, false);
            base.OnActionExecuted(filterContext);
        }
    }
}