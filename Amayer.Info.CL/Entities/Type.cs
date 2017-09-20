using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Info.CL.Entities
{
   public class BaseType: BaseEntity
    {
      

        public string Name { get; set; } 
        public string ParentId { get; set; }

        public string Description { get; set; }
    }
}
