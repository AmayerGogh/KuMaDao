
using Amayer.Info.CL.CRUD;
using Amayer.Info.CL.Data;

using Chloe;
using Chloe.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {




            foreach (var item in Assembly.Load("Amayer.Info").GetTypes())
            {
                if (item.BaseType == typeof(Amayer.Info.Areas.Hp.Controllers.AdminController))
                {
                    System.Console.WriteLine("对了" + item.Name);
                    foreach (var it in item.GetMethods())
                    {
                        foreach (var it_ in it.CustomAttributes)
                        {
                            if (it_.AttributeType.Name == typeof(Amayer.Utility.Filters.JsonFormatterFilter).Name)
                            {
                              
                                System.Console.WriteLine(item.Name + "___" + it.Name + it_.ConstructorArguments[0].Value + "逮到你啦！！");
                                continue;
                            }
                        }
                    }
                }
            }































            //RunAsync<string>(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {                   
            //        Console.WriteLine(i);
            //    }
            //    return "你好";
            //}, (dsf) =>
            //{
            //    Console.WriteLine(dsf);
            //});


            ////    RunAsync<double>((1) => { Console.WriteLine(1); return 1; }, (1) => { Console.WriteLine(2); return 1; });

            ////  DisplayValue(); //这里不会阻塞  
            //Console.WriteLine("MyClass() End.");




            //Func<double, double, string> s = test;

            //var sdd = TryDo<string>((dfg) =>
            //{
            //    Console.WriteLine(dfg);
            //    return 1;
            //}, "e");



            //#region
            ////MsSqlContext db = new MsSqlContext("data source=bds258291696.my3w.com;initial catalog=bds258291696_db;user id=bds258291696;password=12345687;");
            //////var db = new MsSqlContext("data source=bds258291696.my3w.com;initial catalog=bds258291696_db;user id=bds258291696;password=12345687;");

            ////////AdminMenu
            //////IQuery<AdminMenu> q = db.Query<AdminMenu>();
            //////var s = q.ToList();
            //////foreach (var item in s)
            //////{
            //////    Console.WriteLine(item.Name);
            //////}
            //////  StudentSecond ss = Mapper<Student, StudentSecond>.Trans(s)；
            ////Student stu = new Student();
            ////stu.Id = 1;
            ////stu.Name = "你好";
            ////stu.Age = 12;
            ////stu.Gender = false;
            ////// var stuC = Mapper<Student, StudentViewModel>.Trans(stu);

            ////var en = new AdminMenuCRUD(db);
            ////var s = en.ListById<AdminMenu>(1);
            ////var ss = en.ListByWhere<AdminMenu>(m => m.Id != 0&&m.Id!=100).ToList();
            ////foreach (var item in ss)
            ////{
            ////    Console.WriteLine(item.Id);
            ////}            
            ////var p = en.Page<AdminMenu>(2, 2).ToList();
            ////AdminMenu model = new AdminMenu();
            ////model.Name = "5";
            ////var mo = en.Insert<AdminMenu>(model);
            //#endregion
            Console.ReadKey();
        }




        public static Result TryDo<T>(Func<T, int> function, T t)
        {
            var result = new Result();
            try
            {
                result.Status = function(t);
            }
            catch (Exception ex)
            {
                result.Status = -1;
                result.Message = ex.ToString();
            }
            return result;
        }



        public static string test(double d, double c)
        {
            Console.WriteLine(d);
            return "";
        }





        public static Task<double> GetValueAsync(double num1, double num2)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    num1 = num1 / num2;
                    Console.WriteLine(i);
                }
                return num1;
            });
        }

        public static async void DisplayValue()
        {
            double result = await GetValueAsync(1234.5, 1.01);//此处会开新线程处理GetValueAsync任务，然后方法马上返回  
                                                              //这之后的所有代码都会被封装成委托，在GetValueAsync任务完成时调用  
            Console.WriteLine("Value is : " + result);
        }



        public static async void RunAsync(Action function, Action callback)
        {
            await new Func<Task>(() => Task.Run(function)).Invoke();
            callback?.Invoke();
        }

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

    }




    public class JsonAuth
    {
        public int Id { get; set; }
        
        //public int  { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }

       
    }




    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
    }
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public int? Status { get; set; }
    }
    public class Result
    {
        /// <summary>
        /// 状态 -1=错误, 0=失败, 1=成功
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; } = "操作成功";
    }
}

