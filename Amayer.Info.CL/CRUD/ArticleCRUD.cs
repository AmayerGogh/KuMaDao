
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chloe.SqlServer;
using Amayer.Info.CL.Entities;
using Amayer.Utility.Entity;
using Amayer.Info.CL.Dto.Admin;
using System.Linq.Expressions;
using Amayer.Utility.Com;
using Nelibur.ObjectMapper;

namespace Amayer.Info.CL.CRUD
{
  public  class ArticleCRUD : Base<Article>
    {
        private Chloe.IDbContext db;
        public ArticleCRUD(Chloe.IDbContext db) : base(db)
        {
            this.db = db;
        }

        public BsTableResponseModel<ArticleListDto> GetList(BsTableRequestModel param)
        {
            var model = new BsTableResponseModel<ArticleListDto>();
            var lamList = new List<Expression<Func<Article, bool>>>();
            if (!string.IsNullOrWhiteSpace(param.search))
                lamList.Add(m => m.Title.Contains(param.search));
            lamList.Add(m => m.Status == 1);
            // var typeId = ComHelper.Str2Int(param.searches["typeId"]);
            //  if (typeId != 0) lamList.Add(m => m.Type == typeId);
            var count = 0;
            var lam = AmayerHelper.BulidExpression(lamList);
            // List(int offset, int limit, out int count, string orderBy)
            var list = List(lam, param.offset, param.limit, out count, "").ToList();
            model.total = count;

            model.rows = PutTogether(list);
            return model;
        }

        private List<ArticleListDto> PutTogether(List<Article> list)
        {
            var newList = new List<ArticleListDto>();
            foreach (var item in list)
            {
               newList.Add(  TinyMapper.Map<Article, ArticleListDto>(item));
            }
          
            return newList;
        }



    }
}
