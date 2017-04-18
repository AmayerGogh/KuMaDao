using Chloe.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amayer.Info.Controllers
{
    public class BaseController : Controller
    {
        //public MsSqlContext Msc;
        
      


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           // Msc = new MsSqlContext("data source=bds258291696.my3w.com;initial catalog=bds258291696_db;user id=bds258291696;password=12345687;");
            base.OnActionExecuting(filterContext);
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
           // Msc.Dispose();
            base.OnActionExecuted(filterContext);
        }
    }
}