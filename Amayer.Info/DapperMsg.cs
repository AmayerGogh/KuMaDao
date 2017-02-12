using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Amayer.Info
{
    public class DapperMsg
    {
        private const string IDbConnection = "IDbConnection";
        public static void CreateDbContext()
        {
            IDbConnection db = CL.Data.DapperData.QueryDB();
            HttpContext.Current.Items[IDbConnection] = db;
        }
        public static IDbConnection DbContext
        {
            //todo    
            get
            {
                return (IDbConnection)HttpContext.Current.Items[IDbConnection];
            }
        }
        /// <summary>
        /// 销毁DbContext
        /// </summary>
        public static void FinishDbContext()
        {
            DbContext.Dispose();
        }

    }
}