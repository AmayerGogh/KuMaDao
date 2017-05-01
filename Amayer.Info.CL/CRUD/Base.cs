using Amayer.Info.CL.Models;
using Chloe;
using Chloe.SqlServer;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Info.CL.CRUD
{
    public class Base<T> where T : BaseEntity
    {
        //private IDbConnection db;
        //public Base(IDbConnection db)
        //{
        //    this.db = db;
        //}
        public IQuery<T> tt;
        private Chloe.SqlServer.MsSqlContext db;
        public Base(MsSqlContext db)
        {
            this.db = db;
            tt = db.Query<T>();
        }

        public IQuery<T> GetList<S>()
        {          
            return tt;
        }
        public T GetListById<S>(int id)
        {
            return  tt.Where(m => m.Id == id).FirstOrDefault();
        }
        public IQuery<T> GetListByWhere<S>(Expression<Func<T,bool>> where)
        {
            return tt.Where(where);
        }

        public S Insert<S>(S s)
        {
           return  db.Insert(s);
        }


        public IQuery<T> Page<S>(int pageNumber, int pageSize)
        {
           return tt.TakePage(pageNumber,pageSize);
        }


      
      
    }

    

}
