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

        [Utility.Filters.Net2JsonFilter]
        public ActionResult GetList(BsTableResponseModel param)
        {
            BsTableResultModel<ArticleViewModel> model = new BsTableResultModel<ArticleViewModel>();         
            var en = new ArticleCRUD(CholeMsg.DbContext);
            //public int offset { get; set; } //从第几个开始
            //public int limit { get; set; } // 多少个
            model.total = en.Count<Article>();
            var re = en.Page<Article>(param.offset, param.limit).ToList(); //第几页  多少个
           
            model.rows = (from list in re
                     select new ArticleViewModel
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
                     }).ToList();



           // model= TinyMapper.Map<Article,ArticleViewModels>(re);           
            return Json(model);
           // return Json(TinyMapper.Map<ArticleViewModels>(new ArticleCRUD(CholeMsg.DbContext).GetList<Article>().ToList()), JsonRequestBehavior.AllowGet);

        }

        public ActionResult Edit(int? id)
        {
            return View();
        }
    }
}