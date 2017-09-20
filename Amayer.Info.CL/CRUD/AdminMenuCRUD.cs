
using Amayer.Info.CL.Entities;
using Chloe;
using Chloe.SqlServer;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Info.CL.CRUD
{
    public class AdminMenuCRUD : Base<AdminMenu>
    {

        //private IDbConnection db;
        //public AdminMenuCRUD(IDbConnection db) :base(db)
        //{

        //    this.db = db;
        //}
        private MsSqlContext db;
        public AdminMenuCRUD(MsSqlContext db) : base(db)
        {
            this.db = db;
        }


        public IQuery<AdminMenu> GetListWhere()
        {
            IQuery<AdminMenu> q = db.Query<AdminMenu>().Where(a=>a.Id>1);
            return q;
        }

        //public IEnumerable<AdminMenu> GetListWhere()
        //{
        //    return db.Query<AdminMenu>("select * from AdminMenus");
        //}


    }

   
}
