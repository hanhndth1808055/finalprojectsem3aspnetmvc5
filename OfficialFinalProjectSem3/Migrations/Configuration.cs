namespace OfficialFinalProjectSem3.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OfficialFinalProjectSem3.Data;
    using OfficialFinalProjectSem3.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;

    internal sealed class Configuration : DbMigrationsConfiguration<OfficialFinalProjectSem3.Data.MyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyDBContext context)
        {
            SeedingRole(context);
            SeedingUser(context);
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

        private void SeedingRole(MyDBContext context)
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
            }
            context.SaveChanges();
        }

        private void SeedingUser(MyDBContext context)
        {
            try
            {
                using (var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    var admin = new ApplicationUser() { Id = "Admin1", UserName = "Admin1", Email = "admin1@gmail.com", PhoneNumber = "0362655898" };
                    if (userManager.Create(admin, "password123") != IdentityResult.Success)
                    {
                        throw new Exception("Create Failed");
                    }
                    var customer1 = new ApplicationUser() { Id = "Customer1", UserName = "Customer1", Email = "Customer1@gmail.com", PhoneNumber = "0362655891" };
                    if (userManager.Create(customer1, "password123") != IdentityResult.Success)
                    {
                        throw new Exception("Create Failed");
                    }
                    var customer2 = new ApplicationUser() { Id = "Customer2", UserName = "Customer2", Email = "Customer2@gmail.com", PhoneNumber = "0362655892" };
                    if (userManager.Create(customer2, "password123") != IdentityResult.Success)
                    {
                        throw new Exception("Create Failed");
                    }
                    var customer3 = new ApplicationUser() { Id = "Customer3", UserName = "Customer3", Email = "Customer3@gmail.com", PhoneNumber = "0362655899" };
                    if (userManager.Create(customer3, "password123") != IdentityResult.Success)
                    {
                        throw new Exception("Create Failed");
                    }
                    var customer4 = new ApplicationUser() { Id = "Customer4", UserName = "Customer4", Email = "Customer4@gmail.com", PhoneNumber = "0362655894" };
                    if (userManager.Create(customer4, "password123") != IdentityResult.Success)
                    {
                        throw new Exception("Create Failed");
                    }
                    var customer5 = new ApplicationUser() { Id = "Customer5", UserName = "Customer5", Email = "Customer5@gmail.com", PhoneNumber = "0362655899" };
                    if (userManager.Create(customer5, "password123") != IdentityResult.Success)
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
                    userManager.AddToRole(customer1.Id, "Customer");
                    userManager.AddToRole(customer2.Id, "Customer");
                    userManager.AddToRole(customer3.Id, "Customer");
                    userManager.AddToRole(customer4.Id, "Customer");
                    userManager.AddToRole(customer5.Id, "Customer");
                    userManager.AddToRole(staff.Id, "Staff");
                    context.SaveChanges();
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
                CreatedAt = DateTime.Parse("2018-01-13"),
                Thumbnails = "image/upload/v1587907877/rpnm2n9uuxi5aoeyb093.jpg"
            },
                new Product()
            {
                Id = 2,
                Name = "Product 2",
                Price = 5000,
                Status = Product.ProductStatus.DEACTIVE,
                CreatedAt = DateTime.Parse("2018-03-13"),
                Thumbnails = "image/upload/v1587907877/rm7bs0llyz9dzjuiomld.jpg"
            },
                new Product()
            {
                Id = 3,
                Name = "Product 3",
                Price = 3000,
                Status = Product.ProductStatus.ACTIVE,
                CreatedAt = DateTime.Parse("2018-01-10"),
                Thumbnails = "image/upload/v1587907877/y35faenwrkw06ve5gmk4.jpg"
            },
                new Product()
            {
                Id = 4,
                Name = "Product 4",
                Price = 15000,
                Status = Product.ProductStatus.ACTIVE,
                CreatedAt = DateTime.Parse("2018-04-25"),
                Thumbnails = "image/upload/v1587907877/nkcoz6ruhohwbvgu3gir.jpg"
            },
                new Product()
            {
                Id = 5,
                Name = "Product 5",
                Price = 22000,
                Status = Product.ProductStatus.DELETE,
                CreatedAt = DateTime.Parse("2018-01-16"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            },
                new Product()
            {
                Id = 6,
                Name = "Product 6",
                Price = 22000,
                Status = Product.ProductStatus.DELETE,
                CreatedAt = DateTime.Parse("2018-01-20"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            },
            new Product()
            {
                Id = 7,
                Name = "Product 7",
                Price = 28000,
                Status = Product.ProductStatus.ACTIVE,
                CreatedAt = DateTime.Parse("2018-02-20"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            },
            new Product()
            {
                Id = 8,
                Name = "Product 8",
                Price = 50000,
                Status = Product.ProductStatus.ACTIVE,
                CreatedAt = DateTime.Parse("2018-03-28"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            },
            new Product()
            {
                Id = 9,
                Name = "Product 9",
                Price = 40000,
                Status = Product.ProductStatus.DELETE,
                CreatedAt = DateTime.Parse("2018-03-20"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            },
            new Product()
            {
                Id = 10,
                Name = "Product 10",
                Price = 35000,
                Status = Product.ProductStatus.ACTIVE,
                CreatedAt = DateTime.Parse("2018-04-16"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            },
            new Product()
            {
                Id = 11,
                Name = "Product 11",
                Price = 80000,
                Status = Product.ProductStatus.DELETE,
                CreatedAt = DateTime.Parse("2018-05-16"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            },
            new Product()
            {
                Id = 12,
                Name = "Product 12",
                Price = 12000,
                Status = Product.ProductStatus.ACTIVE,
                CreatedAt = DateTime.Parse("2018-06-16"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            },
            new Product()
            {
                Id = 13,
                Name = "Product 13",
                Price = 90000,
                Status = Product.ProductStatus.DELETE,
                CreatedAt = DateTime.Parse("2018-07-16"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            },
            new Product()
            {
                Id = 14,
                Name = "Product 14",
                Price = 60000,
                Status = Product.ProductStatus.DELETE,
                CreatedAt = DateTime.Parse("2018-08-16"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            },
            new Product()
            {
                Id = 15,
                Name = "Product 15",
                Price = 100000,
                Status = Product.ProductStatus.ACTIVE,
                CreatedAt = DateTime.Parse("2018-09-16"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            },
            new Product()
            {
                Id = 16,
                Name = "Product 16",
                Price = 222000,
                Status = Product.ProductStatus.DELETE,
                CreatedAt = DateTime.Parse("2018-10-16"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            },
            new Product()
            {
                Id = 17,
                Name = "Product 17",
                Price = 122000,
                Status = Product.ProductStatus.ACTIVE,
                CreatedAt = DateTime.Parse("2018-11-16"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            },
            new Product()
            {
                Id = 18,
                Name = "Product 18",
                Price = 155000,
                Status = Product.ProductStatus.DELETE,
                CreatedAt = DateTime.Parse("2018-01-16"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            },
            new Product()
            {
                Id = 19,
                Name = "Product 19",
                Price = 250000,
                Status = Product.ProductStatus.ACTIVE,
                CreatedAt = DateTime.Parse("2018-02-16"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            },
            new Product()
            {
                Id = 20,
                Name = "Product 20",
                Price = 240000,
                Status = Product.ProductStatus.DELETE,
                CreatedAt = DateTime.Parse("2018-03-16"),
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
                    UserID = "Customer1",
                    User = context.Users.Find("Customer1")
                },
                new Order()
                {
                    Id = 2,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                    FinishedAt = DateTime.Parse("2020-01-17"),
                    Status = Order.OrderStatus.CANCEL,
                    Total = 26000,
                    UserID = "Customer2",
                    User = context.Users.Find("Customer2")
                },
                new Order()
                {
                    Id = 30,
                    CreatedAt = DateTime.Parse("2019-05-16"),
                    FinishedAt = DateTime.Parse("2019-05-17"),
                    Status = Order.OrderStatus.CANCEL,
                    Total = 26000,
                    UserID = "Customer3",
                    User = context.Users.Find("Customer3")
                },
                new Order()
                {
                    Id = 31,
                    CreatedAt = DateTime.Parse("2019-05-20"),
                    FinishedAt = DateTime.Parse("2019-05-21"),
                    Status = Order.OrderStatus.CANCEL,
                    Total = 24000,
                    UserID = "Customer3",
                    User = context.Users.Find("Customer3")
                },
                new Order()
                {
                    Id = 32,
                    CreatedAt = DateTime.Parse("2019-05-30"),
                    FinishedAt = DateTime.Parse("2019-06-01"),
                    Status = Order.OrderStatus.CANCEL,
                    Total = 40000,
                    UserID = "Customer3",
                    User = context.Users.Find("Customer3")
                },
                new Order()
                {
                    Id = 33,
                    CreatedAt = DateTime.Parse("2019-06-02"),
                    FinishedAt = DateTime.Parse("2019-06-03"),
                    Status = Order.OrderStatus.CANCEL,
                    Total = 51000,
                    UserID = "Customer3",
                    User = context.Users.Find("Customer3")
                },
                new Order()
                {
                    Id = 34,
                    CreatedAt = DateTime.Parse("2019-06-04"),
                    FinishedAt = DateTime.Parse("2019-06-05"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 30000,
                    UserID = "Customer4",
                    User = context.Users.Find("Customer4")
                },
                new Order()
                {
                    Id = 35,
                    CreatedAt = DateTime.Parse("2019-06-16"),
                    FinishedAt = DateTime.Parse("2019-06-17"),
                    Status = Order.OrderStatus.CANCEL,
                    Total = 89000,
                    UserID = "Customer5",
                    User = context.Users.Find("Customer5")
                },
                new Order()
                {
                    Id = 36,
                    CreatedAt = DateTime.Parse("2019-06-10"),
                    FinishedAt = DateTime.Parse("2019-06-21"),
                    Status = Order.OrderStatus.CANCEL,
                    Total = 46000,
                    UserID = "Customer1",
                    User = context.Users.Find("Customer1")
                },
                new Order()
                {
                    Id = 37,
                    CreatedAt = DateTime.Parse("2019-06-21"),
                    FinishedAt = DateTime.Parse("2019-06-23"),
                    Status = Order.OrderStatus.CANCEL,
                    Total = 36000,
                    UserID = "Customer2",
                    User = context.Users.Find("Customer2")
                },
                new Order()
                {
                    Id = 38,
                    CreatedAt = DateTime.Parse("2019-07-16"),
                    FinishedAt = DateTime.Parse("2019-07-20"),
                    Status = Order.OrderStatus.CANCEL,
                    Total = 88000,
                    UserID = "Customer4",
                    User = context.Users.Find("Customer4")
                },
                new Order()
                {
                    Id = 39,
                    CreatedAt = DateTime.Parse("2019-08-16"),
                    FinishedAt = DateTime.Parse("2019-08-17"),
                    Status = Order.OrderStatus.CANCEL,
                    Total = 50000,
                    UserID = "Customer2",
                    User = context.Users.Find("Customer2")
                },
                new Order()
                {
                    Id = 40,
                    CreatedAt = DateTime.Parse("2019-08-17"),
                    FinishedAt = DateTime.Parse("2019-08-18"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 30000,
                    UserID = "Customer1",
                    User = context.Users.Find("Customer1")
                },
                new Order()
                {
                    Id = 41,
                    CreatedAt = DateTime.Parse("2019-08-18"),
                    FinishedAt = DateTime.Parse("2019-08-19"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 30000,
                    UserID = "Customer5",
                    User = context.Users.Find("Customer5")
                },
                new Order()
                {
                    Id = 42,
                    CreatedAt = DateTime.Parse("2019-08-20"),
                    FinishedAt = DateTime.Parse("2019-08-21"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 40000,
                    UserID = "Customer3",
                    User = context.Users.Find("Customer3")
                },
                new Order()
                {
                    Id = 43,
                    CreatedAt = DateTime.Parse("2019-08-22"),
                    FinishedAt = DateTime.Parse("2019-08-23"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 50000,
                    UserID = "Customer2",
                    User = context.Users.Find("Customer2")
                },
                new Order()
                {
                    Id = 44,
                    CreatedAt = DateTime.Parse("2019-08-24"),
                    FinishedAt = DateTime.Parse("2019-08-25"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 60000,
                    UserID = "Customer1",
                    User = context.Users.Find("Customer1")
                },
                new Order()
                {
                    Id = 45,
                    CreatedAt = DateTime.Parse("2019-08-26"),
                    FinishedAt = DateTime.Parse("2019-08-27"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 70000,
                    UserID = "Customer3",
                    User = context.Users.Find("Customer3")
                },
                new Order()
                {
                    Id = 46,
                    CreatedAt = DateTime.Parse("2019-08-28"),
                    FinishedAt = DateTime.Parse("2019-08-29"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 80000,
                    UserID = "Customer4",
                    User = context.Users.Find("Customer4")
                },
                new Order()
                {
                    Id = 47,
                    CreatedAt = DateTime.Parse("2019-09-01"),
                    FinishedAt = DateTime.Parse("2019-09-02"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 90000,
                    UserID = "Customer5",
                    User = context.Users.Find("Customer5")
                },
                new Order()
                {
                    Id = 48,
                    CreatedAt = DateTime.Parse("2019-09-03"),
                    FinishedAt = DateTime.Parse("2019-09-04"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 100000,
                    UserID = "Customer1",
                    User = context.Users.Find("Customer1")
                },
                new Order()
                {
                    Id = 49,
                    CreatedAt = DateTime.Parse("2019-09-06"),
                    FinishedAt = DateTime.Parse("2019-09-08"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 55000,
                    UserID = "Customer3",
                    User = context.Users.Find("Customer3")
                },
                new Order()
                {
                    Id = 50,
                    CreatedAt = DateTime.Parse("2019-09-10"),
                    FinishedAt = DateTime.Parse("2019-09-11"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 60000,
                    UserID = "Customer4",
                    User = context.Users.Find("Customer4")
                },
                new Order()
                {
                    Id = 51,
                    CreatedAt = DateTime.Parse("2019-09-12"),
                    FinishedAt = DateTime.Parse("2019-09-13"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 80000,
                    UserID = "Customer5",
                    User = context.Users.Find("Customer5")
                },
                new Order()
                {
                    Id = 52,
                    CreatedAt = DateTime.Parse("2019-09-14"),
                    FinishedAt = DateTime.Parse("2019-09-15"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 70000,
                    UserID = "Customer2",
                    User = context.Users.Find("Customer2")
                },
                new Order()
                {
                    Id = 53,
                    CreatedAt = DateTime.Parse("2019-09-16"),
                    FinishedAt = DateTime.Parse("2019-09-17"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 70000,
                    UserID = "Customer1",
                    User = context.Users.Find("Customer1")
                },
                new Order()
                {
                    Id = 54,
                    CreatedAt = DateTime.Parse("2019-09-18"),
                    FinishedAt = DateTime.Parse("2019-09-19"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 90000,
                    UserID = "Customer3",
                    User = context.Users.Find("Customer3")
                },
                new Order()
                {
                    Id = 55,
                    CreatedAt = DateTime.Parse("2019-09-20"),
                    FinishedAt = DateTime.Parse("2019-09-21"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 80000,
                    UserID = "Customer2",
                    User = context.Users.Find("Customer2")
                },
                new Order()
                {
                    Id = 56,
                    CreatedAt = DateTime.Parse("2019-09-23"),
                    FinishedAt = DateTime.Parse("2019-09-24"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 110000,
                    UserID = "Customer4",
                    User = context.Users.Find("Customer4")
                },
                new Order()
                {
                    Id = 57,
                    CreatedAt = DateTime.Parse("2019-09-25"),
                    FinishedAt = DateTime.Parse("2019-09-26"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 60000,
                    UserID = "Customer2",
                    User = context.Users.Find("Customer2")
                },
                new Order()
                {
                    Id = 58,
                    CreatedAt = DateTime.Parse("2019-09-28"),
                    FinishedAt = DateTime.Parse("2019-09-29"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 120000,
                    UserID = "Customer1",
                    User = context.Users.Find("Customer1")
                },
                new Order()
                {
                    Id = 59,
                    CreatedAt = DateTime.Parse("2019-09-29"),
                    FinishedAt = DateTime.Parse("2019-09-30"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 110000,
                    UserID = "Customer3",
                    User = context.Users.Find("Customer3")
                },
                new Order()
                {
                    Id = 60,
                    CreatedAt = DateTime.Parse("2019-10-01"),
                    FinishedAt = DateTime.Parse("2019-10-02"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 80000,
                    UserID = "Customer4",
                    User = context.Users.Find("Customer4")
                },
                new Order()
                {
                    Id = 61,
                    CreatedAt = DateTime.Parse("2019-10-10"),
                    FinishedAt = DateTime.Parse("2019-10-11"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 90000,
                    UserID = "Customer5",
                    User = context.Users.Find("Customer5")
                },
                new Order()
                {
                    Id = 62,
                    CreatedAt = DateTime.Parse("2019-10-04"),
                    FinishedAt = DateTime.Parse("2019-10-05"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 80000,
                    UserID = "Customer2",
                    User = context.Users.Find("Customer2")
                },
                new Order()
                {
                    Id = 63,
                    CreatedAt = DateTime.Parse("2019-10-12"),
                    FinishedAt = DateTime.Parse("2019-10-13"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 200000,
                    UserID = "Customer1",
                    User = context.Users.Find("Customer1")
                },
                new Order()
                {
                    Id = 64,
                    CreatedAt = DateTime.Parse("2019-10-15"),
                    FinishedAt = DateTime.Parse("2019-10-16"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 180000,
                    UserID = "Customer3",
                    User = context.Users.Find("Customer3")
                },
                new Order()
                {
                    Id = 65,
                    CreatedAt = DateTime.Parse("2019-10-17"),
                    FinishedAt = DateTime.Parse("2019-10-18"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 850000,
                    UserID = "Customer4",
                    User = context.Users.Find("Customer4")
                },
                new Order()
                {
                    Id = 66,
                    CreatedAt = DateTime.Parse("2019-10-19"),
                    FinishedAt = DateTime.Parse("2019-10-20"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 280000,
                    UserID = "Customer5",
                    User = context.Users.Find("Customer5")
                },
                new Order()
                {
                    Id = 67,
                    CreatedAt = DateTime.Parse("2019-10-21"),
                    FinishedAt = DateTime.Parse("2019-10-22"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 850000,
                    UserID = "Customer4",
                    User = context.Users.Find("Customer4")
                },
                new Order()
                {
                    Id = 68,
                    CreatedAt = DateTime.Parse("2019-10-23"),
                    FinishedAt = DateTime.Parse("2019-10-24"),
                    Status = Order.OrderStatus.CANCEL,
                    Total = 1850000,
                    UserID = "Customer3",
                    User = context.Users.Find("Customer3")
                },
                new Order()
                {
                    Id = 69,
                    CreatedAt = DateTime.Parse("2019-10-25"),
                    FinishedAt = DateTime.Parse("2019-10-26"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 810000,
                    UserID = "Customer2",
                    User = context.Users.Find("Customer2")
                },
                new Order()
                {
                    Id = 70,
                    CreatedAt = DateTime.Parse("2019-11-01"),
                    FinishedAt = DateTime.Parse("2019-11-02"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 840000,
                    UserID = "Customer1",
                    User = context.Users.Find("Customer1")
                },
                new Order()
                {
                    Id = 71,
                    CreatedAt = DateTime.Parse("2019-11-03"),
                    FinishedAt = DateTime.Parse("2019-11-04"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 880000,
                    UserID = "Customer2",
                    User = context.Users.Find("Customer2")
                },
                new Order()
                {
                    Id = 72,
                    CreatedAt = DateTime.Parse("2019-11-05"),
                    FinishedAt = DateTime.Parse("2019-11-06"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 920000,
                    UserID = "Customer3",
                    User = context.Users.Find("Customer3")
                },
                new Order()
                {
                    Id = 73,
                    CreatedAt = DateTime.Parse("2019-11-07"),
                    FinishedAt = DateTime.Parse("2019-11-08"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 940000,
                    UserID = "Customer4",
                    User = context.Users.Find("Customer4")
                },
                new Order()
                {
                    Id = 74,
                    CreatedAt = DateTime.Parse("2019-11-11"),
                    FinishedAt = DateTime.Parse("2019-11-12"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 120000,
                    UserID = "Customer5",
                    User = context.Users.Find("Customer5")
                },
                new Order()
                {
                    Id = 75,
                    CreatedAt = DateTime.Parse("2019-11-13"),
                    FinishedAt = DateTime.Parse("2019-11-14"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 110000,
                    UserID = "Customer2",
                    User = context.Users.Find("Customer2")
                },
                new Order()
                {
                    Id = 76,
                    CreatedAt = DateTime.Parse("2019-11-15"),
                    FinishedAt = DateTime.Parse("2019-11-16"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 140000,
                    UserID = "Customer3",
                    User = context.Users.Find("Customer3")
                },
                new Order()
                {
                    Id = 77,
                    CreatedAt = DateTime.Parse("2019-11-20"),
                    FinishedAt = DateTime.Parse("2019-11-21"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 840000,
                    UserID = "Customer1",
                    User = context.Users.Find("Customer1")
                },
                new Order()
                {
                    Id = 78,
                    CreatedAt = DateTime.Parse("2019-11-22"),
                    FinishedAt = DateTime.Parse("2019-11-23"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 850000,
                    UserID = "Customer4",
                    User = context.Users.Find("Customer4")
                },
                new Order()
                {
                    Id = 79,
                    CreatedAt = DateTime.Parse("2019-11-24"),
                    FinishedAt = DateTime.Parse("2019-11-25"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 870000,
                    UserID = "Customer2",
                    User = context.Users.Find("Customer2")
                },
                new Order()
                {
                    Id = 80,
                    CreatedAt = DateTime.Parse("2019-12-02"),
                    FinishedAt = DateTime.Parse("2019-12-03"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 120000,
                    UserID = "Customer3",
                    User = context.Users.Find("Customer3")
                },
                new Order()
                {
                    Id = 81,
                    CreatedAt = DateTime.Parse("2019-12-04"),
                    FinishedAt = DateTime.Parse("2019-12-05"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 150000,
                    UserID = "Customer1",
                    User = context.Users.Find("Customer1")
                },
                new Order()
                {
                    Id = 82,
                    CreatedAt = DateTime.Parse("2019-12-06"),
                    FinishedAt = DateTime.Parse("2019-12-08"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 140000,
                    UserID = "Customer2",
                    User = context.Users.Find("Customer2")
                },
                new Order()
                {
                    Id = 83,
                    CreatedAt = DateTime.Parse("2019-12-08"),
                    FinishedAt = DateTime.Parse("2019-11-09"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 160000,
                    UserID = "Customer4",
                    User = context.Users.Find("Customer4")
                },
                new Order()
                {
                    Id = 84,
                    CreatedAt = DateTime.Parse("2019-12-10"),
                    FinishedAt = DateTime.Parse("2019-12-11"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 170000,
                    UserID = "Customer2",
                    User = context.Users.Find("Customer2")
                },
                new Order()
                {
                    Id = 85,
                    CreatedAt = DateTime.Parse("2019-12-12"),
                    FinishedAt = DateTime.Parse("2019-12-13"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 100000,
                    UserID = "Customer1",
                    User = context.Users.Find("Customer1")
                },
                new Order()
                {
                    Id = 86,
                    CreatedAt = DateTime.Parse("2019-12-15"),
                    FinishedAt = DateTime.Parse("2019-12-16"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 190000,
                    UserID = "Customer5",
                    User = context.Users.Find("Customer5")
                },
                new Order()
                {
                    Id = 87,
                    CreatedAt = DateTime.Parse("2019-12-17"),
                    FinishedAt = DateTime.Parse("2019-12-18"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 120000,
                    UserID = "Customer1",
                    User = context.Users.Find("Customer1")
                },
                new Order()
                {
                    Id = 88,
                    CreatedAt = DateTime.Parse("2019-12-20"),
                    FinishedAt = DateTime.Parse("2019-12-21"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 100000,
                    UserID = "Customer4",
                    User = context.Users.Find("Customer4")
                },
                new Order()
                {
                    Id = 89,
                    CreatedAt = DateTime.Parse("2019-12-11"),
                    FinishedAt = DateTime.Parse("2019-12-11"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 120000,
                    UserID = "Customer3",
                    User = context.Users.Find("Customer3")
                },
                new Order()
                {
                    Id = 90,
                    CreatedAt = DateTime.Parse("2020-01-02"),
                    FinishedAt = DateTime.Parse("2020-01-03"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 550000,
                    UserID = "Customer5",
                    User = context.Users.Find("Customer5")
                },
                new Order()
                {
                    Id = 91,
                    CreatedAt = DateTime.Parse("2020-01-05"),
                    FinishedAt = DateTime.Parse("2020-01-06"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 550000,
                    UserID = "Customer4",
                    User = context.Users.Find("Customer4")
                },
                new Order()
                {
                    Id = 92,
                    CreatedAt = DateTime.Parse("2020-01-07"),
                    FinishedAt = DateTime.Parse("2020-01-08"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 550000,
                    UserID = "Customer4",
                    User = context.Users.Find("Customer4")
                },
                new Order()
                {
                    Id = 93,
                    CreatedAt = DateTime.Parse("2020-01-10"),
                    FinishedAt = DateTime.Parse("2020-01-11"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 550000,
                    UserID = "Customer2",
                    User = context.Users.Find("Customer2")
                },
                new Order()
                {
                    Id = 94,
                    CreatedAt = DateTime.Parse("2020-01-12"),
                    FinishedAt = DateTime.Parse("2020-01-13"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 550000,
                    UserID = "Customer5",
                    User = context.Users.Find("Customer5")
                },
                new Order()
                {
                    Id = 95,
                    CreatedAt = DateTime.Parse("2020-01-15"),
                    FinishedAt = DateTime.Parse("2020-01-16"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 550000,
                    UserID = "Customer1",
                    User = context.Users.Find("Customer1")
                },
                new Order()
                {
                    Id = 96,
                    CreatedAt = DateTime.Parse("2020-01-17"),
                    FinishedAt = DateTime.Parse("2020-01-18"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 550000,
                    UserID = "Customer4",
                    User = context.Users.Find("Customer4")
                },
                new Order()
                {
                    Id = 97,
                    CreatedAt = DateTime.Parse("2020-01-18"),
                    FinishedAt = DateTime.Parse("2020-01-19"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 550000,
                    UserID = "Customer3",
                    User = context.Users.Find("Customer3")
                },
                new Order()
                {
                    Id = 98,
                    CreatedAt = DateTime.Parse("2020-01-20"),
                    FinishedAt = DateTime.Parse("2020-01-22"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 550000,
                    UserID = "Customer2",
                    User = context.Users.Find("Customer2")
                },
                new Order()
                {
                    Id = 99,
                    CreatedAt = DateTime.Parse("2018-04-23"),
                    FinishedAt = DateTime.Parse("2018-04-24"),
                    Status = Order.OrderStatus.FINISH,
                    Total = 550000,
                    UserID = "Customer1",
                    User = context.Users.Find("Customer1")
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
                    Product = context.Products.Find(1)
                },
                 new OrderDetail()
                {
                    Id = 2,
                    OrderID = 2,
                    Order = context.Orders.Find(2),
                    ProductID = 2,
                    Quantity = 3,
                    Product = context.Products.Find(2)
                },
                 new OrderDetail()
                {
                    Id = 3,
                    OrderID = 30,
                    Order = context.Orders.Find(30),
                    ProductID = 3,
                    Quantity = 4,
                    Product = context.Products.Find(3)
                },
                 new OrderDetail()
                {
                    Id = 4,
                    OrderID = 31,
                    Order = context.Orders.Find(31),
                    ProductID = 4,
                    Quantity = 2,
                    Product = context.Products.Find(4)
                },
                 new OrderDetail()
                {
                    Id = 5,
                    OrderID = 32,
                    Order = context.Orders.Find(32),
                    ProductID = 5,
                    Quantity = 2,
                    Product = context.Products.Find(5)
                },
                 new OrderDetail()
                {
                    Id = 6,
                    OrderID = 34,
                    Order = context.Orders.Find(34),
                    ProductID = 6,
                    Quantity = 2,
                    Product = context.Products.Find(6)
                },
                 new OrderDetail()
                {
                    Id = 7,
                    OrderID = 35,
                    Order = context.Orders.Find(35),
                    ProductID = 7,
                    Quantity = 2,
                    Product = context.Products.Find(7)
                },
                 new OrderDetail()
                {
                    Id = 8,
                    OrderID = 36,
                    Order = context.Orders.Find(36),
                    ProductID = 8,
                    Quantity = 2,
                    Product = context.Products.Find(8)
                },
                 new OrderDetail()
                {
                    Id = 9,
                    OrderID = 37,
                    Order = context.Orders.Find(37),
                    ProductID = 9,
                    Quantity = 2,
                    Product = context.Products.Find(9)
                },
                 new OrderDetail()
                {
                    Id = 10,
                    OrderID = 38,
                    Order = context.Orders.Find(38),
                    ProductID = 10,
                    Quantity = 2,
                    Product = context.Products.Find(10)
                },
                 new OrderDetail()
                {
                    Id = 11,
                    OrderID = 39,
                    Order = context.Orders.Find(39),
                    ProductID = 11,
                    Quantity = 4,
                    Product = context.Products.Find(11)
                },
                 new OrderDetail()
                {
                    Id = 12,
                    OrderID = 40,
                    Order = context.Orders.Find(40),
                    ProductID = 12,
                    Quantity = 5,
                    Product = context.Products.Find(12)
                },
                 new OrderDetail()
                {
                    Id = 13,
                    OrderID = 41,
                    Order = context.Orders.Find(41),
                    ProductID = 13,
                    Quantity = 2,
                    Product = context.Products.Find(13)
                },
                 new OrderDetail()
                {
                    Id = 14,
                    OrderID = 42,
                    Order = context.Orders.Find(42),
                    ProductID = 14,
                    Quantity = 2,
                    Product = context.Products.Find(14)
                },
                 new OrderDetail()
                {
                    Id = 15,
                    OrderID = 43,
                    Order = context.Orders.Find(43),
                    ProductID = 15,
                    Quantity = 2,
                    Product = context.Products.Find(15)
                },
                 new OrderDetail()
                {
                    Id = 16,
                    OrderID = 44,
                    Order = context.Orders.Find(44),
                    ProductID = 16,
                    Quantity = 2,
                    Product = context.Products.Find(16)
                },
                 new OrderDetail()
                {
                    Id = 17,
                    OrderID = 45,
                    Order = context.Orders.Find(45),
                    ProductID = 1,
                    Quantity = 2,
                    Product = context.Products.Find(17)
                },
                 new OrderDetail()
                {
                    Id = 18,
                    OrderID = 46,
                    Order = context.Orders.Find(46),
                    ProductID = 18,
                    Quantity = 2,
                    Product = context.Products.Find(18)
                },
                 new OrderDetail()
                {
                    Id = 19,
                    OrderID = 47,
                    Order = context.Orders.Find(47),
                    ProductID = 19,
                    Quantity = 2,
                    Product = context.Products.Find(19)
                },
                 new OrderDetail()
                {
                    Id = 20,
                    OrderID = 48,
                    Order = context.Orders.Find(48),
                    ProductID = 20,
                    Quantity = 2,
                    Product = context.Products.Find(20)
                },

        };
            context.OrderDetails.AddOrUpdate(arrOrderDetails);
        }
    }
}
