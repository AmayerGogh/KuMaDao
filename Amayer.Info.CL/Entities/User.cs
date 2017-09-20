using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Info.CL.Entities
{
   public class User: BaseEntity
    {
     
        public string UserInfo { get; set; }
        public string PasswordCalc { get; set; }
    }
}
