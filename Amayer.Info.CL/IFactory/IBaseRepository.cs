using Chloe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Info.CL.IFactory
{
    public  interface IBaseRepository
    {
        //IQuery<T> List<S>();
       
        //T ListById<S>(int id)
       
        //public int Count<S>()
        //{
        //    return tt.Count();
        //}
        //public int Count<S>(Expression<Func<T, bool>> where)
        //{
        //    return tt.Where(where).Count();
        //}
        //public IQuery<T> ListByWhere<S>(Expression<Func<T, bool>> where)
        //{
        //    return tt.Where(where);
        //}

        //public S Insert<S>(S s)
        //{
        //    return db.Insert(s);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="S"></typeparam>
        ///// <param name="pageNumber">第几页</param>
        ///// <param name="pageSize"></param>
        ///// <returns></returns>
        //public IQuery<T> TakePage<S>(int pageNumber, int pageSize)
        //{

        //    return tt.TakePage(pageNumber, pageSize);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="S"></typeparam>
        ///// <param name="offset">从第几页开始</param>
        ///// <param name="pageSize"></param>
        ///// <returns></returns>
        //public IQuery<T> Page<S>(int offset, int pageSize)
        //{

        //    return tt.Skip(offset).Take(pageSize);
        //}
    }
}
