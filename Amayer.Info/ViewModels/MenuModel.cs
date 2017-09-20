
using Amayer.Info.CL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amayer.Info.ViewModels
{
    public class MenuModel
    {
        public AdminMenu ActiveMenu { get; set; }
        public AdminMenu TopMenu { get; set; }
        public List<Menu> Menus { get; set; }

       // public CurrentUser User { get; set; }
    }

    public class Menu
    {
        public long Id { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }
        public int ParentId { get; set; }
        public int Sort { get; set; }
        public bool IsFinal { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }

        public List<AdminMenu> Children { get; set; }
    }
}