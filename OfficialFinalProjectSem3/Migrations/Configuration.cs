namespace OfficialFinalProjectSem3.Migrations
{
    using OfficialFinalProjectSem3.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OfficialFinalProjectSem3.Data.MyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OfficialFinalProjectSem3.Data.MyDBContext";
        }

        protected override void Seed(OfficialFinalProjectSem3.Data.MyDBContext context)
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE Products");
            context.Products.AddOrUpdate(new Product()
            {
                Id = 1,
                Name = "Product 1",
                Price = 2000,
                Status = Product.ProductStatus.ACTIVE,
                CreatedAt = DateTime.Parse("2020-01-13"),
                Thumbnails = "image/upload/v1587835038/ma0qbjmf8jqvbhwhqycs.jpg"
            }
            );
        }
    }
}
