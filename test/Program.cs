
using Amayer.Info.CL.CRUD;
using Amayer.Info.CL.Data;
using Amayer.Info.CL.Models;
using Chloe;
using Chloe.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            MsSqlContext db = new MsSqlContext("data source=bds258291696.my3w.com;initial catalog=bds258291696_db;user id=bds258291696;password=12345687;");
            //var db = new MsSqlContext("data source=bds258291696.my3w.com;initial catalog=bds258291696_db;user id=bds258291696;password=12345687;");

            ////AdminMenu
            //IQuery<AdminMenu> q = db.Query<AdminMenu>();
            //var s = q.ToList();
            //foreach (var item in s)
            //{
            //    Console.WriteLine(item.Name);
            //}
            //  StudentSecond ss = Mapper<Student, StudentSecond>.Trans(s)；
            Student stu = new Student();
            stu.Id = 1;
            stu.Name = "你好";
            stu.Age = 12;
            stu.Gender = false;
            // var stuC = Mapper<Student, StudentViewModel>.Trans(stu);

            var en = new AdminMenuCRUD(db);
            var s = en.GetListById<AdminMenu>(1);
            var ss = en.GetListByWhere<AdminMenu>(m => m.Id != 0&&m.Id!=100).ToList();
            foreach (var item in ss)
            {
                Console.WriteLine(item.Id);
            }            
            var p = en.Page<AdminMenu>(2, 2).ToList();
            AdminMenu model = new AdminMenu();
            model.Name = "5";
            var mo = en.Insert<AdminMenu>(model);
            Console.ReadKey();
        }


        
    }

    public class Student
    {
        public int Id { get; set; }
        public  string Name { get; set; }
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
}

