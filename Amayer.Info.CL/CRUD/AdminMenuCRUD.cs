using Amayer.Info.CL.Models;
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
    public class AdminMenuCRUD:Base<AdminMenu>
    {

        private IDbConnection db;//= Amayer.Info.CL.Data.DapperData.QueryDB();
        public AdminMenuCRUD(IDbConnection db) :base(db)
        {
           // db =  Amayer.Info.CL.Data.DapperData.QueryDB();
            this.db = db;
        }

       

        //public IEnumerable<AdminMenu> GetListWhere()
        //{
        //    return db.Query<AdminMenu>("select * from AdminMenus");
        //}

       
    }

   
}
