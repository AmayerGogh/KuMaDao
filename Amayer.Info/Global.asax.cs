using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Amayer.Info
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();          
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);          
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            //请求开始之前创建本次请求用到的DbContext
            //One DbContext Per Request
            //DbContext不是线程安全的
            DapperMsg.CreateDbContext();
        }

        protected void Application_EndRequest()
        {

            //本次请求结束销毁DbContext
            DapperMsg.FinishDbContext();
        }
    }
}
