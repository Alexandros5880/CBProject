using CBProject.Models;
using CBProject.Models.EntityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CBProject.HelperClasses
{
    public static class CreateData
    {
        public static void CreateUsersAndRoles(ApplicationDbContext context)
        {
            try
            {
                if (!context.Roles.Any(r => r.Name == "Admin"))
                {
                    var store_1 = new RoleStore<IdentityRole>(context);
                    var manager_1 = new RoleManager<IdentityRole>(store_1);
                    var role_1 = new IdentityRole { Name = "Admin" };
                    manager_1.Create(role_1);
                }
                if (!context.Roles.Any(r => r.Name == "Teacher"))
                {
                    var store_2 = new RoleStore<IdentityRole>(context);
                    var manager_2 = new RoleManager<IdentityRole>(store_2);
                    var role_2 = new IdentityRole { Name = "Teacher" };
                    manager_2.Create(role_2);
                }
                if (!context.Roles.Any(r => r.Name == "Student"))
                {
                    var store_3 = new RoleStore<IdentityRole>(context);
                    var manager_3 = new RoleManager<IdentityRole>(store_3);
                    var role_3 = new IdentityRole { Name = "Student" };
                    manager_3.Create(role_3);
                }
                if (!context.Roles.Any(r => r.Name == "Guest"))
                {
                    var store_3 = new RoleStore<IdentityRole>(context);
                    var manager_3 = new RoleManager<IdentityRole>(store_3);
                    var role_3 = new IdentityRole { Name = "Guest" };
                    manager_3.Create(role_3);
                }

                var user_1 = new ApplicationUser()
                {
                    BirthDate = DateTime.Today.AddYears(-30),
                    FirstName = "Alexandros_1",
                    LastName = "Platanios_1",
                    Email = "alexandrosplatanios1@gmail.com",
                    UserName = "alexandrosplatanios1@gmail.com",
                    PhoneNumber = "6949277781",
                    Password = "Takara0000",
                    Country = "Greece",
                    State = "Attica",
                    City = "Voula",
                    PostalCode = "16673",
                    Street = "Fleming",
                    StreetNumber = "14",
                    IsInactive = false,
                    ImagePath = "/assets/images/users/avatar-1.jpg"
                };
                var user_2 = new ApplicationUser()
                {
                    BirthDate = DateTime.Today.AddYears(-30),
                    FirstName = "Alexandros_2",
                    LastName = "Platanios_2",
                    Email = "alexandrosplatanios2@gmail.com",
                    UserName = "alexandrosplatanios2@gmail.com",
                    PhoneNumber = "6949277782",
                    Password = "Takara0000",
                    Country = "Greece",
                    State = "Attica",
                    City = "Voula",
                    PostalCode = "16673",
                    Street = "Fleming",
                    StreetNumber = "14",
                    IsInactive = false,
                    ImagePath = "/assets/images/users/avatar-2jpg"
                };
                var user_3 = new ApplicationUser()
                {
                    BirthDate = DateTime.Today.AddYears(-30),
                    FirstName = "Alexandros_3",
                    LastName = "Platanios_3",
                    Email = "alexandrosplatanios3@gmail.com",
                    UserName = "alexandrosplatanios3@gmail.com",
                    PhoneNumber = "6949277783",
                    Password = "Takara0000",
                    Country = "Greece",
                    State = "Attica",
                    City = "Voula",
                    PostalCode = "16673",
                    Street = "Fleming",
                    StreetNumber = "14",
                    IsInactive = false,
                    ImagePath = "/assets/images/users/avatar-3.jpg"
                };
                var user_4 = new ApplicationUser()
                {
                    BirthDate = DateTime.Today.AddYears(-30),
                    FirstName = "Alexandros_4",
                    LastName = "Platanios_4",
                    Email = "alexandrosplatanios4@gmail.com",
                    UserName = "alexandrosplatanios4@gmail.com",
                    PhoneNumber = "6949277784",
                    Password = "Takara0000",
                    Country = "Greece",
                    State = "Attica",
                    City = "Voula",
                    PostalCode = "16673",
                    Street = "Fleming",
                    StreetNumber = "14",
                    IsInactive = false,
                    ImagePath = "/assets/images/users/avatar-4.jpg"
                };
                var user_5 = new ApplicationUser()
                {
                    BirthDate = DateTime.Today.AddYears(-30),
                    FirstName = "Alexandros_5",
                    LastName = "Platanios_5",
                    Email = "alexandrosplatanios5@gmail.com",
                    UserName = "alexandrosplatanios5@gmail.com",
                    PhoneNumber = "6949277784",
                    Password = "Takara0000",
                    Country = "Greece",
                    State = "Attica",
                    City = "Voula",
                    PostalCode = "16673",
                    Street = "Fleming",
                    StreetNumber = "14",
                    IsInactive = false,
                    ImagePath = "/assets/images/users/avatar-5.jpg"
                };
                var user_6 = new ApplicationUser()
                {
                    BirthDate = DateTime.Today.AddYears(-30),
                    FirstName = "Antonis",
                    LastName = "Ploumis",
                    Email = "djplou@hotmail.com",
                    UserName = "djplou@hotmail.com",
                    PhoneNumber = "6945857485",
                    Password = "Antonis123!",
                    Country = "Greece",
                    State = "Attica",
                    City = "Athens",
                    PostalCode = "11147",
                    Street = "Athens",
                    StreetNumber = "14",
                    IsInactive = false,
                    ImagePath = "/assets/images/users/avatar-6.jpg"
                };

                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                manager.Create(user_1, user_1.Password);
                manager.Create(user_2, user_2.Password);
                manager.Create(user_3, user_3.Password);
                manager.Create(user_4, user_4.Password);
                manager.Create(user_5, user_5.Password);
                manager.Create(user_6, user_6.Password);
                if (!manager.IsInRole(user_1.Id, "Admin"))
                {
                    manager.AddToRole(user_1.Id, "Admin");
                }
                if (!manager.IsInRole(user_2.Id, "Teacher"))
                {
                    manager.AddToRole(user_2.Id, "Teacher");
                }
                if (!manager.IsInRole(user_3.Id, "Student"))
                {
                    manager.AddToRole(user_3.Id, "Student");
                }
                if (!manager.IsInRole(user_4.Id, "Student"))
                {
                    manager.AddToRole(user_4.Id, "Student");
                }
                if (!manager.IsInRole(user_5.Id, "Admin"))
                {
                    manager.AddToRole(user_5.Id, "Admin");
                }
                if (!manager.IsInRole(user_6.Id, "Guest"))
                {
                    manager.AddToRole(user_6.Id, "Guest");
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CreateCategories(ApplicationDbContext context)
        {
            try
            {
                Category category1 = new Category()
                {
                    ID = 1,
                    Name = ".NET",
                    Master = true
                };
                Category category2 = new Category()
                {
                    ID = 2,
                    Name = "FRAMEWORK",
                    Master = true
                };
                Category category3 = new Category()
                {
                    ID = 3,
                    Name = "CORE",
                    Master = true
                };
                Category category4 = new Category()
                {
                    ID = 4,
                    Name = "MVC",
                    Master = false
                };
                Category category5 = new Category()
                {
                    ID = 5,
                    Name = "XAMARIN",
                    Master = false
                };
                Category category6 = new Category()
                {
                    ID = 6,
                    Name = "WPF",
                    Master = false
                };
                context.Categories.Add(category1);
                context.Categories.Add(category2);
                context.Categories.Add(category3);
                context.Categories.Add(category4);
                context.Categories.Add(category5);
                context.Categories.Add(category6);

                CategoryToCategory catToCat1 = new CategoryToCategory()
                {
                    ID = 7,
                    MasterCategory = category1,
                    ChiledCategory = category2
                };
                CategoryToCategory catToCat2 = new CategoryToCategory()
                {
                    ID = 8,
                    MasterCategory = category1,
                    ChiledCategory = category3
                };
                CategoryToCategory catToCat3 = new CategoryToCategory()
                {
                    ID = 9,
                    MasterCategory = category2,
                    ChiledCategory = category4
                };
                CategoryToCategory catToCat4 = new CategoryToCategory()
                {
                    ID = 10,
                    MasterCategory = category3,
                    ChiledCategory = category4
                };
                CategoryToCategory catToCat5 = new CategoryToCategory()
                {
                    ID = 11,
                    MasterCategory = category3,
                    ChiledCategory = category5
                };
                CategoryToCategory catToCat6 = new CategoryToCategory()
                {
                    ID = 12,
                    MasterCategory = category3,
                    ChiledCategory = category6
                };
                context.CategoriesToCategories.Add(catToCat1);
                context.CategoriesToCategories.Add(catToCat2);
                context.CategoriesToCategories.Add(catToCat3);
                context.CategoriesToCategories.Add(catToCat4);
                context.CategoriesToCategories.Add(catToCat5);
                context.CategoriesToCategories.Add(catToCat6);

                context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CreateContentTypes(ApplicationDbContext context)
        {
            try
            {
                ContentType content1 = new ContentType()
                {
                    ID = 1,
                    Name = "ContentType1"
                };
                ContentType content2 = new ContentType()
                {
                    ID = 2,
                    Name = "ContentType2"
                };
                ContentType content3 = new ContentType()
                {
                    ID = 3,
                    Name = "ContentType3"
                };
                ContentType content4 = new ContentType()
                {
                    ID = 4,
                    Name = "ContentType4"
                };
                ContentType content5 = new ContentType()
                {
                    ID = 5,
                    Name = "ContentType5"
                };
                ContentType content6 = new ContentType()
                {
                    ID = 6,
                    Name = "ContentType6"
                };
                ContentType content7 = new ContentType()
                {
                    ID = 7,
                    Name = "ContentType7"
                };
                ContentType content8 = new ContentType()
                {
                    ID = 8,
                    Name = "ContentType8"
                };
                ContentType content9 = new ContentType()
                {
                    ID = 9,
                    Name = "ContentType9"
                };
                ContentType content10 = new ContentType()
                {
                    ID = 10,
                    Name = "ContentType10"
                };
                ContentType content11 = new ContentType()
                {
                    ID = 11,
                    Name = "ContentType11"
                };
                context.ContentTypes.Add(content1);
                context.ContentTypes.Add(content2);
                context.ContentTypes.Add(content3);
                context.ContentTypes.Add(content4);
                context.ContentTypes.Add(content5);
                context.ContentTypes.Add(content6);
                context.ContentTypes.Add(content7);
                context.ContentTypes.Add(content8);
                context.ContentTypes.Add(content9);
                context.ContentTypes.Add(content10);
                context.ContentTypes.Add(content11);
                context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CreatePayments(ApplicationDbContext context)
        {
            try
            {
                Payment payment1 = new Payment()
                {
                    ID = 1,
                    PaymentMethods = PaymentMethods.Paypal,
                    User = (ApplicationUser)context.Users.FirstOrDefault(U => U.FirstName.Equals("Alexandros_1")),
                    Price = 100M,
                    Tax = 24.00,
                    Discount = 00.33
                };
                Payment payment2 = new Payment()
                {
                    ID = 2,
                    PaymentMethods = PaymentMethods.DebitCard,
                    User = (ApplicationUser)context.Users.FirstOrDefault(U => U.FirstName.Equals("Alexandros_2")),
                    Price = 100M,
                    Tax = 24.00,
                    Discount = 00.33
                };
                Payment payment3 = new Payment()
                {
                    ID = 3,
                    PaymentMethods = PaymentMethods.BankTransfer,
                    User = (ApplicationUser)context.Users.FirstOrDefault(U => U.FirstName.Equals("Alexandros_3")),
                    Price = 100M,
                    Tax = 24.00,
                    Discount = 00.33
                };
                Payment payment4 = new Payment()
                {
                    ID = 4,
                    PaymentMethods = PaymentMethods.Paypal,
                    User = (ApplicationUser)context.Users.FirstOrDefault(U => U.FirstName.Equals("Alexandros_4")),
                    Price = 100M,
                    Tax = 24.00,
                    Discount = 00.33
                };
                Payment payment5 = new Payment()
                {
                    ID = 5,
                    PaymentMethods = PaymentMethods.DebitCard,
                    User = (ApplicationUser)context.Users.FirstOrDefault(U => U.FirstName.Equals("Alexandros_5")),
                    Price = 100M,
                    Tax = 24.00,
                    Discount = 00.33
                };
                context.Payments.Add(payment1);
                context.Payments.Add(payment2);
                context.Payments.Add(payment3);
                context.Payments.Add(payment4);
                context.Payments.Add(payment5);
                context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CreateSubscriptionPackages(ApplicationDbContext context)
        {
            try
            {
                SubscriptionPackage package1 = new SubscriptionPackage()
                {
                    ID = 1,
                    Name = "PACKAGE 1",
                    Price = 100,
                    Duration = 23.33f,
                    MyUsers = new List<ApplicationUser>()
                    {
                        context.Users.FirstOrDefault()
                    },
                    ContentType = context.ContentTypes.FirstOrDefault(c => c.ID == 1),
                    AutoSubscription = true,
                    StartDate = DateTime.Today,
                    Payment = context.Payments.FirstOrDefault(p => p.ID == 1)
                };
                SubscriptionPackage package2 = new SubscriptionPackage()
                {
                    ID = 2,
                    Name = "PACKAGE 2",
                    Price = 100,
                    Duration = 23.33f,
                    MyUsers = new List<ApplicationUser>()
                    {
                        context.Users.FirstOrDefault()
                    },
                    ContentType = context.ContentTypes.FirstOrDefault(c => c.ID == 2),
                    AutoSubscription = true,
                    StartDate = DateTime.Today,
                    Payment = context.Payments.FirstOrDefault(p => p.ID == 2)
                };
                SubscriptionPackage package3 = new SubscriptionPackage()
                {
                    ID = 3,
                    Name = "PACKAGE 3",
                    Price = 100,
                    Duration = 23.33f,
                    MyUsers = new List<ApplicationUser>()
                    {
                        context.Users.FirstOrDefault()
                    },
                    ContentType = context.ContentTypes.FirstOrDefault(c => c.ID == 3),
                    AutoSubscription = true,
                    StartDate = DateTime.Today,
                    Payment = context.Payments.FirstOrDefault(p => p.ID == 3)
                };
                SubscriptionPackage package4 = new SubscriptionPackage()
                {
                    ID = 4,
                    Name = "PACKAGE 4",
                    Price = 100,
                    Duration = 23.33f,
                    MyUsers = new List<ApplicationUser>()
                    {
                        context.Users.FirstOrDefault()
                    },
                    ContentType = context.ContentTypes.FirstOrDefault(c => c.ID == 4),
                    AutoSubscription = true,
                    StartDate = DateTime.Today,
                    Payment = context.Payments.FirstOrDefault(p => p.ID == 4)
                };
                SubscriptionPackage package5 = new SubscriptionPackage()
                {
                    ID = 5,
                    Name = "PACKAGE 5",
                    Price = 100,
                    Duration = 23.33f,
                    MyUsers = new List<ApplicationUser>()
                    {
                        context.Users.FirstOrDefault()
                    },
                    ContentType = context.ContentTypes.FirstOrDefault(c => c.ID == 5),
                    AutoSubscription = true,
                    StartDate = DateTime.Today,
                    Payment = context.Payments.FirstOrDefault(p => p.ID == 5)
                };
                context.SubcriptionPackages.Add(package1);
                context.SubcriptionPackages.Add(package2);
                context.SubcriptionPackages.Add(package3);
                context.SubcriptionPackages.Add(package4);
                context.SubcriptionPackages.Add(package5);
                context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CreateEbook(ApplicationDbContext context)
        {
            try
            {
                // TODO: Create Ebooks
                Ebook ebook1 = new Ebook()
                {
                    // TODO: Create Ebbooks
                };
                // TODO: Add all ebooks
                context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CreateVideo(ApplicationDbContext context)
        {
            try
            {
                // Todo: Create Video
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CreateRating(ApplicationDbContext context)
        {
            try
            {
                // TODO: Create Rating
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CreateReview(ApplicationDbContext context)
        {
            try
            {
                // TODO: Create Review
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}