using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WcfService3.Models
{
    public class WebServiceDbContext: DbContext
    {
        public WebServiceDbContext()
            : base("name=WebServiceDbContext")
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}