using Amayer.Info.CL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chloe.SqlServer;

namespace Amayer.Info.CL.CRUD
{
  public  class ArticleCRUD : Base<Article>
    {
        private MsSqlContext db;
        public ArticleCRUD(MsSqlContext db) : base(db)
        {
            this.db = db;
        }
    }
}
