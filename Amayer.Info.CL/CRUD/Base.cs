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
    public class Base<T> where T : class
    {
        private IDbConnection db;
        public Base(IDbConnection db)
        {
            this.db = db;
        }


        public IEnumerable<T> GetList(string table)
        {
           
            var sql = "select * from @t ".Replace("@t", table);
            return db.Query<T>(sql);            
        }

        public IEnumerable<T> GetList(string table, string wherever)
        {
            var sql = "select * from @t where @wherever ".Replace("@t", table);
            return db.Query<T>(sql, new { wherever = wherever});
        }
        
        

    }


   
}
