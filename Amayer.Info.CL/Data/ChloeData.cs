using Chloe;
using Chloe.SqlServer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Info.CL.Data
{
    public class ChloeData
    {
       // IDbContext context = new MsSqlContext(DapperData.QueryDB().ToString());
        //IQuery<User> q = context.Query<User>();
        public static Chloe.IDbContext Init()
        {
            var comm = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            return new MsSqlContext(comm);
        }

        public static Chloe.IDbContext Chole(string comm)
        {
            return new MsSqlContext(comm);
        }
        public static void Dispose(Chloe.IDbContext db)
        {
            if (db != null)
            {
                db.Dispose();
            }
        }

    }


}
