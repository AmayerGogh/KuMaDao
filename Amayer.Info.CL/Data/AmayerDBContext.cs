using Amayer.Info.CL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Info.CL.Data
{
    class AmayerDBContext:DbContext
    {
        public AmayerDBContext()
            : base("name=conn")
        {
            Database.SetInitializer<AmayerDBContext>(null);
            this.Configuration.ProxyCreationEnabled = false;
         
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<WebInfo> WebInfoes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Lable> Lables { get; set; }
        //角色
        //public DbSet<Role> Roles { get; set; }


    }
}
