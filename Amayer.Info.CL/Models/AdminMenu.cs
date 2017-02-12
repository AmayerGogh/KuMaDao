using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Info.CL.Models
{
   public class AdminMenu
    {        
        public int Id { get; set; }
        [MaxLength(32)]
        public string Name { get; set; }        
        public string Icon { get; set; }        
        public string Controller { get; set; }        
        public string Action { get; set; }        
        public string Area { get; set; } 
        public string Description { get; set; }
        public int ParentId { get; set; }
        public int Sort { get; set; }
        public bool IsFinal { get; set; }
        public int Status { get; set; }
    }
}
