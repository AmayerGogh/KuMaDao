using Amayer.Utility.Entity;
using Amayer.Utility.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Utility.Com
{
    public class AmayerHelper
    {



        /* 
         使用
          var sdd = TryDo<string>((dfg) =>  { Console.WriteLine(dfg);return 1;}, "e");
         */
        /// <summary>
        /// 执行一个方法，返回方法的执行结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="function"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Result TryDo<T>(Func<T, int> function, T t)
        {
            var result = new Result();
            try
            {
                result.status = function(t);
            }
            catch (Exception ex)
            {
                result.status = -1;
                result.message = ex.ToString();
            }
            return result;
        }

        public static Result TryDo<T, S>(Func<T, S, int> function, T t, S s)
        {
            var result = new Result();
            try
            {
                result.status = function(t, s);
            }
            catch (Exception ex)
            {
                result.status = -1;
                result.message = ex.ToString();
            }
            return result;
        }

        public static Result TryDo<T>(Func<T, int> function, T t, Action action)
        {
            var result = new Result();
            try
            {
                result.status = function(t);
            }
            catch (Exception ex)
            {
                result.status = -1;
                result.message = ex.ToString();
            }

            action();
            return result;
        }

        public static async void RunAsync(Action function, Action callback)
        {
            await new Func<Task>(() => Task.Run(function)).Invoke();
            callback?.Invoke();
        }



        //RunAsync<string>(() =>
        //    {
        //        for (int i = 0; i< 100; i++)
        //        {                   
        //            Console.WriteLine(i);
        //        }
        //        return "你好";
        //    }, (dsf) =>
        //    {
        //        Console.WriteLine(dsf);
        //    });
        /// <summary>  
        /// 将一个方法function异步运行，在执行完毕时执行回调callback  
        /// </summary>  
        /// <typeparam name="T">异步方法的返回类型</typeparam>  
        /// <param name="function">异步方法，该方法没有参数，返回类型必须是TResult</param>  
        /// <param name="callback">异步方法执行完毕时执行的回调方法，该方法参数为TResult，返回类型必须是void</param>  
        public static async void RunAsync<T>(Func<T> function, Action<T> callback)
        {
            Func<Task<T>> taskFunc = () =>
            {
                return Task.Run(() =>
                {
                    return function();
                });
            };
            T rlt = await taskFunc();
            if (callback != null)
                callback(rlt);
        }

        public static void test()
        {

            Func<int, int, int> math = (param1, param2) =>
            {
                return param1 + param2;
            };

            Func<string, int> sd = (str) =>
            {
                return 1;
            };

            var sdd = TryDo<string>((dfg) => {
                return 1;
            }, "e");


            //TryDo<>
        }


        /// <summary>
        /// 由表达式树集合构建表达式树
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> BulidExpression<T>(List<Expression<Func<T, bool>>> list)
        {
            Expression<Func<T, bool>> lam = null;
            list.Add(m => 1 == 1); //至少也要有一个条件
            foreach (var expression in list)
            {
                lam = lam == null ? expression : lam.And(expression);
            }
            return lam;
        }


        public static void Batch2ChangeList<T>(List<T> list, Func<T> func)
        {
            foreach (var item in list)
            {
                //func(item);
            }
        }
        public static void Batch2ChangeList<T>(List<T> list, Action<T> func)
        {
            foreach (var item in list)
            {
                func(item);
            }
        }

    }
}
