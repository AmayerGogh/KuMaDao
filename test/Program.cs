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
            //private static readonly string connstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
            //Data Source=121.42.151.160;Initial Catalog=HuiPu;Persist Security Info=True;User ID=sa;Password=***********;MultipleActiveResultSets=True;Application Name=EntityFramework
            string sql = "select id ,Sort from AdminMenus ";
            StringBuilder sb = new StringBuilder();
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection("data source=bds258291696.my3w.com;initial catalog=bds258291696_db;Persist Security Info=True;user id=bds258291696;password=12345687;MultipleActiveResultSets=True;Application Name=EntityFramework"))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = sql;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        table.Load(reader);
                    }
                }
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string temp = "update AdminMenus set Sort =" + (i + 1) + " where id =" + table.Rows[i]["id"] + ";";
                    sb.Append(temp);
                }
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sb.ToString();

                    int count = cmd.ExecuteNonQuery();
                    Console.WriteLine(count);
                }

            }
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine(sb.ToString());

            Console.ReadKey();
        }
    }
}
