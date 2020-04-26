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
            Product[] arrProducts = {
                new Product()
            {
                Id = 1,
                Name = "Product 1",
                Price = 10000,
                Status = Product.ProductStatus.ACTIVE,
                CreatedAt = DateTime.Parse("2020-01-13"),
                Thumbnails = "image/upload/v1587907877/rpnm2n9uuxi5aoeyb093.jpg"
            },
                new Product()
            {
                Id = 2,
                Name = "Product 2",
                Price = 5000,
                Status = Product.ProductStatus.DEACTIVE,
                CreatedAt = DateTime.Parse("2020-03-13"),
                Thumbnails = "image/upload/v1587907877/rm7bs0llyz9dzjuiomld.jpg"
            },
                new Product()
            {
                Id = 3,
                Name = "Product 3",
                Price = 3000,
                Status = Product.ProductStatus.ACTIVE,
                CreatedAt = DateTime.Parse("2020-01-10"),
                Thumbnails = "image/upload/v1587907877/y35faenwrkw06ve5gmk4.jpg"
            },
                new Product()
            {
                Id = 4,
                Name = "Product 4",
                Price = 15000,
                Status = Product.ProductStatus.ACTIVE,
                CreatedAt = DateTime.Parse("2020-04-25"),
                Thumbnails = "image/upload/v1587907877/nkcoz6ruhohwbvgu3gir.jpg"
            },
                new Product()
            {
                Id = 5,
                Name = "Product 5",
                Price = 22000,
                Status = Product.ProductStatus.DELETE,
                CreatedAt = DateTime.Parse("2019-01-16"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            },

            };
            context.Products.AddOrUpdate(arrProducts);
        }
    }
}
