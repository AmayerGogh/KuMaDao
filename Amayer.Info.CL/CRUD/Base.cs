using Amayer.Info.CL.IFactory;
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

        public IQuery<T> List<S>()
        {          
            return tt;
        }
        public T ListById<S>(int id)
        {
            return  tt.Where(m => m.Id == id).FirstOrDefault();
        }
        public int Count<S>()
        {
            return tt.Count();
        }
        public int Count<S>(Expression<Func<T, bool>> where)
        {
          return  tt.Where(where).Count();
        }
        public IQuery<T> ListByWhere<S>(Expression<Func<T,bool>> where)
        {
            return tt.Where(where);
        }

        public S Insert<S>(S s)
        {
           return  db.Insert(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageNumber">第几页</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IQuery<T> TakePage<S>(int pageNumber, int pageSize)
        {

           return tt.TakePage(pageNumber,pageSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="offset">从第几页开始</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IQuery<T> Page<S>(int offset, int pageSize)
        {

            return tt.Skip(offset).Take(pageSize);
        }



    }

    

}
