
using Amayer.Info.CL.CRUD;

using Amayer.Utility.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Amayer.Info.Areas.Hp.Controllers
{
 
    public class ArticleController : AdminController
    {
        // GET: Hp/Article
       public ActionResult Index()
        {
            return View();
        }

        [Utility.Filters.JsonFormatterFilter(desc:"123123")]
        [AllowAnonymous]
        public ActionResult GetList(BsTableRequestModel param)
        {
             
            var en = new ArticleCRUD(db);
            return Json(en.GetList(param));

        }

        public ActionResult Edit(int? id)
        {
            return View();
        }
    }
}