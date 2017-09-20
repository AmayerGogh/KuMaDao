using Autofac;
using Chloe.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using System.Reflection;
using Amayer.Info.CL.Data;

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


            ModelBinders.Binders.Add(typeof(string), new Amayer.Utility.MVC.TrimToDBCModelBinder());
      
            log4net.Config.XmlConfigurator.Configure();


            //依赖注入
            //var builder = new ContainerBuilder();
            //SetupResolveRules(builder);
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
            //AreaRegistration.RegisterAllAreas();
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            // AuthConfig.RegisterAuth();
        }

        protected void Application_BeginRequest()
        {
            //请求开始之前创建本次请求用到的DbContext
            //One DbContext Per Request
            //DbContext不是线程安全的
            // CholeMsg.CreateDbContext();
            HttpContext.Current.Items["IDbConnection"] =  ChloeData.Init();
        }

        protected void Application_EndRequest()
        {

           var con = (Chloe.IDbContext)HttpContext.Current.Items["IDbConnection"];
            if (con!=null)
            {
                con.Dispose();
            }
            //本次请求结束销毁DbContext
          //  CholeMsg.FinishDbContext();
        }
    }

 

}
