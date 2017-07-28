
//using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Amayer.Info.App_Start
{
    public class ErrorFilter : IExceptionFilter
    {

        //private static ILog log = LogManager.GetLogger(typeof(ErrorFilter));
        public void OnException(ExceptionContext filterContext)
        {

            //new FilterExtension().LogError(log, filterContext.Exception);
          //  Utility.Log.LogError(typeof(ErrorFilter), filterContext.Exception);
            //LogError()
        }
    }
}
