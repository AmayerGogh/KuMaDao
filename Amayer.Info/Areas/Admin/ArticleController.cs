using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amayer.Info.Areas.Admin
{
    public class ArticleController : Controllers.BaseController
    {
        // GET: Admin/Article
        public ActionResult Index()
        {
            return View();
        }
    }
}