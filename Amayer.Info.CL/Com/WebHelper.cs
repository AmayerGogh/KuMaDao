using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;

using System.IO;
using System.Configuration;
using Amayer.Info.CL.ComMsg;

namespace Amayer.Info.CL.Com
{
    public class WebHelper
    {
        public delegate int DoEventHandlers(Object o);
        public Result TryDoSomething(DoEventHandlers db, Object o)
        {
            var result = new Result();
            try
            {
                result.Status = db(o);
            }
            catch (Exception ex)
            {
                result.Status = -1;
                result.Message = ex.ToString();
            }
            return result;
        }



    }
}
