using Amayer.Info.CL.Entities;
using Amayer.Info.CL.IFactory;
using Amayer.Utility.Entity;
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
    public class Base<T>
    {
      
        private IDbContext db;
        public Base()
        {
            if (db == null)
            {
                db = Data.ChloeData.Init();
            }
        }
        public Base(Chloe.IDbContext cc)
        {
            this.db = cc;
        }
        ~Base()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

        protected T Single(Expression<Func<T, bool>> predicate)
        {
            return db.Query<T>().FirstOrDefault(predicate);
        }

        protected IQuery<T> List()
        {
            return db.Query<T>();
        }
        protected IQuery<T> Where(Expression<Func<T, bool>> predicate)
        {
            return db.Query<T>().Where(predicate);
        }
        protected int Count()
        {
            return db.Query<T>().Count();
        }
        protected int Count(Expression<Func<T, bool>> where)
        {
          return db.Query<T>().Where(where).Count();
        }
        protected IQuery<T> List(Expression<Func<T, bool>> predicate,int offset, int limit, out int count, Expression<Func<T, bool>> orderBy, Expression<Func<T, bool>> thenBy = null)
        {
            var ccc = db.Query<T>();
            count = ccc.Count();
            if (thenBy == null)
            {
                return ccc.OrderBy(orderBy).Skip(offset).Take(limit);
            }
            else
            {
                return ccc.OrderBy(orderBy).ThenBy(thenBy).Skip(offset).Take(limit);
            }
        }
        protected IQuery<T> List(Expression<Func<T, bool>> predicate,int offset, int limit, out int count,string orderBy)
        {
            var ccc = db.Query<T>();
            count = ccc.Count();
            if (string.IsNullOrWhiteSpace( orderBy))
            {
                return ccc.Skip(offset).Take(limit);
            }
            return ccc.OrderBy(orderBy).Skip(offset).Take(limit);
            
        }

        protected IQuery<T> ListSelect(Expression<Func<T, bool>> predicate, int offset, int limit, Expression<Func<T, T>> selector)
        {
              return db.Query<T>().Where(predicate).OrderBy(m => m.Id).Skip(offset).Take(limit).Select(selector);
        }
        protected T Insert(T t)
        {
           return  db.Insert(t);
        }
        protected Result AddRange(List<T> t)
        {
            try
            {
                foreach (var item in t)
                {
                    db.Insert(item);
                }
                return new Result() { status = 1 };
            }
            catch (Exception e)
            {
                return new Result() { message = e.ToString() };
            }
        }
        protected int Add(Expression<Func<T>> content)
        {
            return (int)db.Insert(content);
           

        }
        protected Result Update(T t)
        {
            return Utility.Com.AmayerHelper.TryDo(m1 =>
            {
                // var chole = ChloeInit.Chole();
                //var entity = GetSingle(m => m.Id == m1.Id);
                db.TrackEntity(t);
                // TinyMapper.Map(entity, m1);
                return db.Update(t);

            }, t);
        }


        protected Result Update(Expression<Func<T, bool>> condition, Expression<Func<T, T>> content)
        {
            return Utility.Com.AmayerHelper.TryDo((m1, m2) =>
            {
                return db.Update(m1, m2);
            }, condition, content);

        }










    }

    

}
