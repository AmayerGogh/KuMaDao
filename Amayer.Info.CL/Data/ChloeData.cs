using Chloe;
using Chloe.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Info.CL.Data
{
    public class ChloeData
    {
        IDbContext context = new MsSqlContext(DapperData.QueryDB().ToString());
        //IQuery<User> q = context.Query<User>();
    }


}
