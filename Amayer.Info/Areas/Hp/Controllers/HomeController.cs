using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amayer.Info.Areas.Hp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Hp/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult APage()
        {
            return View();
        }
    }
}