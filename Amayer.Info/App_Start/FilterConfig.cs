using Amayer.Info.App_Start;
using System.Web;
using System.Web.Mvc;

namespace Amayer.Info
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ActionFilter());       
            filters.Add(new ErrorFilter());
           
        }
    }
}
