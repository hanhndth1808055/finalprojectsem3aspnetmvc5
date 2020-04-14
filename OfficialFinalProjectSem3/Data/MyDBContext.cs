using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using OfficialFinalProjectSem3.Models;

namespace OfficialFinalProjectSem3.Data
{
    public class MyDBContext : IdentityDbContext<ApplicationUser>
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MyDBContext() : base("name=MyDBContext")
        {
        }

        public static MyDBContext Create()
        {
            return new MyDBContext();
        }

        public System.Data.Entity.DbSet<OfficialFinalProjectSem3.Models.Product> Products { get; set; }
    }
}
