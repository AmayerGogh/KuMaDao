
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Dynamic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Amayer.Info.CL.Data
{
    public class DapperData
    {
        public static IDbConnection QueryDB()
        {
             //return new DbContext().ConnectionStringName("conn",);
             return new SqlConnection("data source=bds258291696.my3w.com;initial catalog=bds258291696_db;user id=bds258291696;password=12345687;");
        }
        //IDbConnection conn = new SqlConnection("data source=.;initial catalog=AmayerOA;user id=sa;password=12345687");


      
    }
}
