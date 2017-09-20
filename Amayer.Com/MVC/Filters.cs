
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Amayer.Utility.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public  class JsonFormatterFilter : ActionFilterAttribute
    {
        string desc { get; set; }
        bool isTodoValid { get; set; }
        public JsonFormatterFilter(string desc, bool isTodoValid = true)
        {
            this.desc = desc;
            this.isTodoValid = isTodoValid;
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Result = new FilterExtension().Net2Json(filterContext.Result);

        }
    }
   
    class FilterExtension
    {
        public ActionResult Net2Json(ActionResult Result)
        {
            //把 filterContext.Result从JsonResult换成JsonNetResult
            //filterContext.Result值得就是Action执行返回的ActionResult对象

            if (Result is JsonResult && !(Result is JsonNetResult))
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
