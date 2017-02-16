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

namespace Amayer.Info.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var model = new HomeViewModel();
           var entity = new AdminMenuCRUD(DapperMsg.DbContext);
             model.AdminMenus = entity.GetList("AdminMenus");                   

            //   var result =  connection.Execute("insert into student values (@Name,@Gender)", new Student { Name = "234", Gender = true });

            //var result= conn.Execute("update student set name =@Name where id=@id ", new { Name = "dapper更改的", id = 4 });
           //  var s  = entity.GetStu();
             //this
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
            string sql = "select id from 表 where orderby * * *";
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