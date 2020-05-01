namespace OfficialFinalProjectSem3.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OfficialFinalProjectSem3.Data;
    using OfficialFinalProjectSem3.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyDBContext context)
        {
            SeedingUserAndRole(context);
            SeedingProduct(context);
            SeedingOrder(context);
            SeedingOrderDetail(context);
        }

        private void Truncate(MyDBContext context)
        {
            //context.Database.ExecuteSqlCommand("DROP TABLE dbo.MigrationsHistory");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.AspNetRoleClaims");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.AspNetUserLogins");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.AspNetUserRoles");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.AspNetRoles");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.AspNetUsers");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE Products");
        }

        private void SeedingUserAndRole(MyDBContext context)
        {
            try
            {
                using (var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    using (var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                    {
                        if (!roleManager.RoleExists("Admin"))
                        {
                            roleManager.Create(new IdentityRole("Admin"));
                        }
                        if (!roleManager.RoleExists("Customer"))
                        {
                            roleManager.Create(new IdentityRole("Customer"));
                        }
                        if (!roleManager.RoleExists("Staff"))
                        {
                            roleManager.Create(new IdentityRole("Staff"));
                        }
                        var admin = new ApplicationUser() { Id = "Admin1", UserName = "Admin1", Email = "admin1@gmail.com", PhoneNumber = "0362655898" };
                        if (userManager.Create(admin, "password123") != IdentityResult.Success)
                        {
                            throw new Exception("Create Failed");
                        }
                        var customer = new ApplicationUser() { Id = "Customer1", UserName = "Customer1", Email = "Customer1@gmail.com", PhoneNumber = "0362655891" };
                        if (userManager.Create(customer, "password123") != IdentityResult.Success)
                        {
                            throw new Exception("Create Failed");
                        }
                        var customer2 = new ApplicationUser() { Id = "Customer2", UserName = "Customer2", Email = "Customer2@gmail.com", PhoneNumber = "0362655892" };
                        if (userManager.Create(customer2, "password123") != IdentityResult.Success)
                        {
                            throw new Exception("Create Failed");
                        }
                        var staff = new ApplicationUser() { Id = "Staff1", UserName = "Staff1", Email = "Staff1@gmail.com", PhoneNumber = "0362655893" };
                        if (userManager.Create(staff, "password123") != IdentityResult.Success)
                        {
                            throw new Exception("Create Failed");
                        }
                        //ADD ROLE
                        userManager.AddToRole(admin.Id, "Admin");
                        userManager.AddToRole(customer.Id, "Customer");
                        userManager.AddToRole(customer2.Id, "Customer");
                        userManager.AddToRole(staff.Id, "Staff");
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        Console.WriteLine("Hello");
                        Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

        private void SeedingProduct(MyDBContext context)
        {
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

        //SEEDING ORDER
        private void SeedingOrder(MyDBContext context)
        {
            Order[] arrOrders =
            {
                new Order()
                {
                    Id = 1,
                    CreatedAt = DateTime.Parse("2019-01-16"),
                    FinishedAt = DateTime.Parse("2019-01-17"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 20000,
                    UserID = "Customer",
                    User = context.Users.Where(p => p.Id == "Customer").FirstOrDefault()
                },
                new Order()
                {
                    Id = 2,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                    FinishedAt = DateTime.Parse("2020-01-17"),
                    Status = Order.OrderStatus.CANCEL,
                    Total = 26000,
                    UserID = "Customer2",
                    User = context.Users.Where(p => p.Id == "Customer2").FirstOrDefault()
                },
            };
            context.Orders.AddOrUpdate(arrOrders);
        }

        private void SeedingOrderDetail(MyDBContext context)
        {
            OrderDetail[] arrOrderDetails = 
            {
                new OrderDetail()
                {
                    Id = 1,
                    OrderID = 1,
                    Order = context.Orders.Find(1),
                    ProductID = 1,
                    Quantity = 2,
                    Product = context.Products.Where(p => p.Id == 1).FirstOrDefault()
                }
            };
            context.OrderDetails.AddOrUpdate(arrOrderDetails);
        }
    }
}

