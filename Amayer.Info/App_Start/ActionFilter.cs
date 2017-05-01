using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amayer.Info.App_Start
{
    public class ActionFilter: IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Result = new Amayer.Utility.MVC.Filter().Net2JsonFilter(filterContext.Result);
        }



        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}