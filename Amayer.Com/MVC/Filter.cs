using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Amayer.Utility.MVC
{
   public class Filter
    {
     
        public void LogError(ILog log,Exception ex)
        {
            log.Error("出现未处理异常" + ex);
        }
       
        public ActionResult Net2JsonFilter(ActionResult Result)
        {
            //把 filterContext.Result从JsonResult换成JsonNetResult
            //filterContext.Result值得就是Action执行返回的ActionResult对象

            if (Result is JsonResult
                && !(Result is JsonNetResult))
            {
                JsonResult jsonResult = (JsonResult)Result;
                JsonNetResult jsonNetResult = new JsonNetResult();
                jsonNetResult.ContentEncoding = jsonResult.ContentEncoding;
                jsonNetResult.ContentType = jsonResult.ContentType;
                jsonNetResult.Data = jsonResult.Data;
                jsonNetResult.JsonRequestBehavior = jsonResult.JsonRequestBehavior;
                jsonNetResult.MaxJsonLength = jsonResult.MaxJsonLength;
                jsonNetResult.RecursionLimit = jsonResult.RecursionLimit;
                Result = jsonNetResult;
            }
            return Result;
        }

    }
}
