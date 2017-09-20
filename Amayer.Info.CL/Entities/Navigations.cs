using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Info.CL.Entities
{
   public class Navigations
    {
        public int Id { get; set; }

        [MaxLength(32)]
        public string Icon { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(32)]
        public string Controller { get; set; }

        [MaxLength(32)]
        public string Action { get; set; }

        public int ParentId { get; set; }
        public int ModuleId { get; set; }
        public int Target { get; set; }
        public int Sort { get; set; }
        public bool IsDisplay { get; set; }

        public bool IsNavigation { get; set; }

        public int Status { get; set; }

       
    }
}
