using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amayer.Info.Areas.Hp.Controllers
{
    public class AdminController : Controller
    {
        protected  Chloe.IDbContext db;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            db = (Chloe.IDbContext)filterContext.HttpContext.Items["IDbConnection"];
        }

    }
}