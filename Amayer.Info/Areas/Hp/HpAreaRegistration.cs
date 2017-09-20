using System.Web.Mvc;

namespace Amayer.Info.Areas.Hp
{
    public class HpAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Hp";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Hp_default",
                "Hp/{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "Amayer.Info.Areas.Hp.Controllers" }
            );
           
        }
    }
}