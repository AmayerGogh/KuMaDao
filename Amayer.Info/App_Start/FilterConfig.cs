using System.Web;
using System.Web.Mvc;

namespace Amayer.Info
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //GlobalFilters.Filters.Add(new Amayer.Utility.MVC.)
           // filters.Add(new Amayer.Utility.MVC.ErrorFilter());
           // filters.Add(new Amayer.Utility)
        }
    }
}
