
using Amayer.Info.CL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amayer.Info.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<AdminMenu> AdminMenus { get; set; }
    }
}