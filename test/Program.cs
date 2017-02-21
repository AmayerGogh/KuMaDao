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
            List<Person> list = new List<test.Program.Person>();
            list.Add(new Person() { name = "1", say = "1111" });
            foreach (var item in list)
            {
                if (item.name =="1")
                {
                    item.say = ":";
                }
            }
            for (int i = 0; i < list.Count(); i++)
            {
                Console.WriteLine(list[i].say);
            }
            
            Console.ReadKey();
        }

        public class Person
        {
            public string name { get; set; }
            public string say { get; set; }
        }
    }
}
