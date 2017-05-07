using Amayer.Info.CL.CRUD;
using Amayer.Info.CL.Models;
using Amayer.Info.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Chloe.SqlServer;

namespace Amayer.Info.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var model = new HomeViewModel();
            //dapper的用法
            //var entity = new AdminMenuCRUD(DapperMsg.DbContext);
         
            var en =  new AdminMenuCRUD(CholeMsg.DbContext);
            var s = en.ListById<AdminMenu>(1);
            var ss = en.ListByWhere<AdminMenu>(m => m.Id == 1).FirstOrDefault();
            return View(model);
        }

        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Index3()
        {
            return View();
        }
        public ActionResult Pic()
        {
            return View();
        }

        public ActionResult SQL()
        {
           // string sql = "select id from 表 where orderby * * *";
            StringBuilder sb = new StringBuilder();
            sb.Append("update CourseWare  set ");
            DataTable table = new DataTable();
            using (SqlConnection conn =new SqlConnection ())
            {
                using (SqlCommand cmd =conn.CreateCommand())
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                       
                        table.Load(reader);
                    }
                }
            }

      
         
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string temp = "set TSort =" + (i + 1) + " where id =" + table.Rows[i]["id"] + ",";
                sb.Append(temp); 
            }

            return View();
        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public int TeacherId { get; set; }

    }
}