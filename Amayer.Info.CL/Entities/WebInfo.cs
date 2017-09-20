using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Info.CL.Entities
{
   public class WebInfo: BaseEntity
    {
      
        public string Key { get; set; }
        public string Value { get; set; }

        public int RoleId { get; set; }
    }
}
