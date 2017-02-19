using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Info.CL.Models
{
   public class BaseType
    {
        public int Id { get; set; }

        public string Name { get; set; } 
        public string ParentId { get; set; }

        public string Description { get; set; }
    }
}
