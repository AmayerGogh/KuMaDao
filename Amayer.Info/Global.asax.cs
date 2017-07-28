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
            CholeMsg.CreateDbContext();
        }

        protected void Application_EndRequest()
        {

            //本次请求结束销毁DbContext
            CholeMsg.FinishDbContext();
        }
    }

    public class DapperMsg
    {
        private const string IDbConnection = "IDbConnection";
        public static void CreateDbContext()
        {
            IDbConnection db = CL.Data.DapperData.QueryDB();
            System.Web.HttpContext.Current.Items[IDbConnection] = db;
        }
        public static IDbConnection DbContext
        {
            //todo    
            get
            {
                return (IDbConnection)HttpContext.Current.Items[IDbConnection];
            }
        }
        /// <summary>
        /// 销毁DbContext
        /// </summary>
        public static void FinishDbContext()
        {
            DbContext.Dispose();
        }
    }

    public class CholeMsg
    {
        private const string IDbConnection = "IDbConnection";
        public static void CreateDbContext()
        {
            MsSqlContext db = new MsSqlContext("data source=bds258291696.my3w.com;initial catalog=bds258291696_db;user id=bds258291696;password=12345687;");
            System.Web.HttpContext.Current.Items[IDbConnection] = db;
        }
        public static MsSqlContext DbContext
        {
            //todo    
            get
            {
                return (MsSqlContext)HttpContext.Current.Items[IDbConnection];
            }
        }
        /// <summary>
        /// 销毁DbContext
        /// </summary>
        public static void FinishDbContext()
        {
            DbContext.Dispose();
        }
    }

}
