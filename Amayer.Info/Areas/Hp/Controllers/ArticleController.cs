using Amayer.Info.Areas.Hp.ViewModel;
using Amayer.Info.CL.CRUD;
using Amayer.Info.CL.Models;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amayer.Info.Areas.Hp.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Hp/Article
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetList()
        {

            var model = new  List< ArticleViewModels>();          
            var en = new ArticleCRUD(CholeMsg.DbContext);
            var re = en.GetList<Article>().ToList();
            model = (from list in re
                     select new ArticleViewModels
                     {
                         Id = list.Id,
                         Navigation = list.Navigation,
                         Category = list.Category,
                         Cover = list.Cover,
                         Title = list.Title,
                         Descript = list.Descript,
                         Content = list.Content,
                         IsTop = list.IsTop,
                         Style = list.Style,
                         Clicks = list.Clicks,
                         CreateTime = list.CreateTime,
                         IsClosed = list.IsClosed,
                         Status = list.Status
                     }).ToList();



           // model= TinyMapper.Map<Article,ArticleViewModels>(re);           
            return Json(model,JsonRequestBehavior.AllowGet);
           // return Json(TinyMapper.Map<ArticleViewModels>(new ArticleCRUD(CholeMsg.DbContext).GetList<Article>().ToList()), JsonRequestBehavior.AllowGet);

        }
    }
}