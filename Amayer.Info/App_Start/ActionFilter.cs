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
          
        }



        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
          
        }
    }


    //public class Net2JsonFilter : IActionFilter
    //{
    //    public void OnActionExecuted(ActionExecutedContext filterContext)
    //    {
    //        filterContext.Result = new Amayer.Utility.MVC.Filter().Net2JsonFilter(filterContext.Result);
          
    //    }

    //    public void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}