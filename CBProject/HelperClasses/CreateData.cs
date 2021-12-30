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
                    var store_1 = new RoleStore<ApplicationRole>(context);
                    var manager_1 = new RoleManager<ApplicationRole>(store_1);
                    var role_1 = new ApplicationRole { Name = "Admin", Level = RoleLevel.FULL };
                    manager_1.Create(role_1);
                }
                if (!context.Roles.Any(r => r.Name == "Manager"))
                {
                    var store_2 = new RoleStore<ApplicationRole>(context);
                    var manager_2 = new RoleManager<ApplicationRole>(store_2);
                    var role_2 = new ApplicationRole { Name = "Manager", Level = RoleLevel.PLUSSFULL };
                    manager_2.Create(role_2);
                }
                if (!context.Roles.Any(r => r.Name == "Teacher"))
                {
                    var store_3 = new RoleStore<ApplicationRole>(context);
                    var manager_3 = new RoleManager<ApplicationRole>(store_3);
                    var role_3 = new ApplicationRole { Name = "Teacher", Level = RoleLevel.MIDDLE };
                    manager_3.Create(role_3);
                }
                if (!context.Roles.Any(r => r.Name == "Student"))
                {
                    var store_4 = new RoleStore<ApplicationRole>(context);
                    var manager_4 = new RoleManager<ApplicationRole>(store_4);
                    var role_4 = new ApplicationRole { Name = "Student", Level = RoleLevel.LOW };
                    manager_4.Create(role_4);
                }
                if (!context.Roles.Any(r => r.Name == "Guest"))
                {
                    var store_5 = new RoleStore<ApplicationRole>(context);
                    var manager_5 = new RoleManager<ApplicationRole>(store_5);
                    var role_5 = new ApplicationRole { Name = "Guest", Level = RoleLevel.SUPERLOW };
                    manager_5.Create(role_5);
                }


                var user_1 = new ApplicationUser()
                {
                    Id = "1",
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
                    Id = "2",
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
                    Id = "3",
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
                    Id = "4",
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
                    Id = "5",
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
                    Id = "6",
                    BirthDate = DateTime.Today.AddYears(-30),
                    FirstName = "Antonis",
                    LastName = "Ploumis",
                    Email = "ant.ploumis@gmail.com",
                    UserName = "ant.ploumis@gmail.com",
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

                var store = new UserStore<ApplicationUser, ApplicationRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>(context);
                CBProject.ApplicationUserManager manager = new CBProject.ApplicationUserManager(store);

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
                if (!manager.IsInRole(user_2.Id, "Manager"))
                {
                    manager.AddToRole(user_2.Id, "Manager");
                }
                if (!manager.IsInRole(user_3.Id, "Teacher"))
                {
                    manager.AddToRole(user_3.Id, "Teacher");
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
            }
            catch (Exception ex)
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
            }
            catch (Exception ex)
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
            }
            catch (Exception ex)
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
            }
            catch (Exception ex)
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
                    Description = "Basic",
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
                    Description = "Advance",
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
                    Description = "Premium",
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
                context.SubcriptionPackages.Add(package1);
                context.SubcriptionPackages.Add(package2);
                context.SubcriptionPackages.Add(package3);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CreateEbook(ApplicationDbContext context)
        {
            try
            {
                Ebook ebook1 = new Ebook()
                {
                    ID = 1,
                    Title = "C# 2010",
                    Description = "FIFTH EDITION",
                    Thumbnail = "Thubnail",
                    EbookImagePath = StaticImfo.EbooksImagesPath + "ebook_1.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + "ebook_1",
                    Url = "url",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(c => c.Name.Equals(".NET"))
                };
                Ebook ebook2 = new Ebook()
                {
                    ID = 2,
                    Title = "WPF",
                    Description = "User Interface Framework",
                    Thumbnail = "Thubnail",
                    EbookImagePath = StaticImfo.EbooksImagesPath + "ebook_2.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + "ebook_2",
                    Url = "url",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(c => c.Name.Equals("CORE"))
                };
                Ebook ebook3 = new Ebook()
                {
                    ID = 3,
                    Title = "XAMARIN",
                    Description = "Cros Platform Framework. (Windows, Linux, Mac, IOS)",
                    Thumbnail = "Thubnail",
                    EbookImagePath = StaticImfo.EbooksImagesPath + "ebook_3.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + "ebook_3",
                    Url = "url",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(c => c.Name.Equals("CORE"))
                };
                Ebook ebook4 = new Ebook()
                {
                    ID = 4,
                    Title = "C++",
                    Description = "FIFTH EDITION",
                    Thumbnail = "Thubnail",
                    EbookImagePath = StaticImfo.EbooksImagesPath + "ebook_4.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + "ebook_4",
                    Url = "url",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(c => c.Name.Equals(".NET"))
                };
                Ebook ebook5 = new Ebook()
                {
                    ID = 5,
                    Title = "MVC",
                    Description = "User Interface Framework",
                    Thumbnail = "Thubnail",
                    EbookImagePath = StaticImfo.EbooksImagesPath + "ebook_5.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + "ebook_5",
                    Url = "url",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(c => c.Name.Equals("CORE"))
                };
                Ebook ebook6 = new Ebook()
                {
                    ID = 6,
                    Title = "MVC",
                    Description = "Cros Platform Framework. (Windows, Linux, Mac, IOS)",
                    Thumbnail = "Thubnail",
                    EbookImagePath = StaticImfo.EbooksImagesPath + "ebook_6.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + "ebook_6",
                    Url = "url",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(c => c.Name.Equals("FRAMEWORK"))
                };
                Ebook ebook7 = new Ebook()
                {
                    ID = 7,
                    Title = "EntityFramework",
                    Description = "User Interface Framework",
                    Thumbnail = "Thubnail",
                    EbookImagePath = StaticImfo.EbooksImagesPath + "ebook_7.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + "ebook_7",
                    Url = "url",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(c => c.Name.Equals("CORE"))
                };
                Ebook ebook8 = new Ebook()
                {
                    ID = 8,
                    Title = "EntityFramework",
                    Description = "Cros Platform Framework. (Windows, Linux, Mac, IOS)",
                    Thumbnail = "Thubnail",
                    EbookImagePath = StaticImfo.EbooksImagesPath + "ebook_8.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + "ebook_8",
                    Url = "url",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(c => c.Name.Equals("FRAMEWORK"))
                };
                context.Ebooks.Add(ebook1);
                context.Ebooks.Add(ebook2);
                context.Ebooks.Add(ebook3);
                context.Ebooks.Add(ebook4);
                context.Ebooks.Add(ebook5);
                context.Ebooks.Add(ebook6);
                context.Ebooks.Add(ebook7);
                context.Ebooks.Add(ebook8);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CreateVideo(ApplicationDbContext context)
        {
            try
            {
                var video_1 = new Video()
                {
                    ID = 1,
                    Title = "MVC_EP_1",
                    Thumbnail = "mvc_ep_1",
                    VideoImagePath = StaticImfo.VideoImagePath + "video_1.jpg",
                    VideoPath = StaticImfo.VideoPath + "video.mp4",
                    Description = "mvc_ep_1",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(cat => cat.Name.Equals("FRAMEWORK")),
                    Url = "www.mvc_ep_1.com"
                };
                var video_2 = new Video()
                {
                    ID = 2,
                    Title = "MVC_EP_2",
                    Thumbnail = "mvc_ep_2",
                    VideoImagePath = StaticImfo.VideoImagePath + "video_2.jpg",
                    VideoPath = StaticImfo.VideoPath + "video.mp4",
                    Description = "mvc_ep_2",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(cat => cat.Name.Equals("FRAMEWORK")),
                    Url = "www.mvc_ep_2.com"
                };
                var video_3 = new Video()
                {
                    ID = 3,
                    Title = "MVC_EP_3",
                    Thumbnail = "mvc_ep_",
                    VideoImagePath = StaticImfo.VideoImagePath + "video_3.jpg",
                    VideoPath = StaticImfo.VideoPath + "video.mp4",
                    Description = "mvc_ep_",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(cat => cat.Name.Equals("FRAMEWORK")),
                    Url = "www.mvc_ep_3.com"
                };
                var video_4 = new Video()
                {
                    ID = 4,
                    Title = "XAMARIN_EP_1",
                    Thumbnail = "xamarin_ep_1",
                    VideoImagePath = StaticImfo.VideoImagePath + "video_4.jpg",
                    VideoPath = StaticImfo.VideoPath + "video.mp4",
                    Description = "xamarin_ep_1",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(cat => cat.Name.Equals("CORE")),
                    Url = "www.xamarin_ep_1.com"
                };
                var video_5 = new Video()
                {
                    ID = 5,
                    Title = "XAMARIN_EP_2",
                    Thumbnail = "xamarin_ep_2",
                    VideoImagePath = StaticImfo.VideoImagePath + "video_5.jpg",
                    VideoPath = StaticImfo.VideoPath + "video.mp4",
                    Description = "xamarin_ep_2",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(cat => cat.Name.Equals("CORE")),
                    Url = "www.xamarin_ep_2.com"
                };
                var video_6 = new Video()
                {
                    ID = 6,
                    Title = "XAMARIN_EP_3",
                    Thumbnail = "xamarin_ep_3",
                    VideoImagePath = StaticImfo.VideoImagePath + "video_6.png",
                    VideoPath = StaticImfo.VideoPath + "video.mp4",
                    Description = "xamarin_ep_3",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(cat => cat.Name.Equals("CORE")),
                    Url = "www.xamarin_ep_3.com"
                };
                var video_7 = new Video()
                {
                    ID = 7,
                    Title = "WPF_EP_1",
                    Thumbnail = "wpf_ep_1",
                    VideoImagePath = StaticImfo.VideoImagePath + "video_7.jpg",
                    VideoPath = StaticImfo.VideoPath + "video.mp4",
                    Description = "wpf_ep_1",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(cat => cat.Name.Equals("CORE")),
                    Url = "www.wpf_ep_1.com"
                };
                var video_8 = new Video()
                {
                    ID = 8,
                    Title = "WPF_EP_2",
                    Thumbnail = "wpf_ep_2",
                    VideoImagePath = StaticImfo.VideoImagePath + "video_8.jpg",
                    VideoPath = StaticImfo.VideoPath + "video.mp4",
                    Description = "wpf_ep_2",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(cat => cat.Name.Equals("CORE")),
                    Url = "www.wpf_ep_2.com"
                };
                var video_9 = new Video()
                {
                    ID = 9,
                    Title = "WPF_EP_3",
                    Thumbnail = "wpf_ep_3",
                    VideoImagePath = StaticImfo.VideoImagePath + "video_9.jpg",
                    VideoPath = StaticImfo.VideoPath + "video.mp4",
                    Description = "wpf_ep_3",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(cat => cat.Name.Equals("CORE")),
                    Url = "wpf_ep_3"
                };
                var video_10 = new Video()
                {
                    ID = 10,
                    Title = "C++",
                    Thumbnail = "C++",
                    VideoImagePath = StaticImfo.VideoImagePath + "video_10.jpg",
                    VideoPath = StaticImfo.VideoPath + "video.mp4",
                    Description = "C++",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(cat => cat.Name.Equals(".NET")),
                    Url = "www.c++.com"
                };
                var video_11 = new Video()
                {
                    ID = 11,
                    Title = "C#",
                    Thumbnail = "C#",
                    VideoImagePath = StaticImfo.VideoImagePath + "video_11.jpg",
                    VideoPath = StaticImfo.VideoPath + "video.mp4",
                    Description = "C#",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(cat => cat.Name.Equals(".NET")),
                    Url = "www.c#.com"
                };
                var video_12 = new Video()
                {
                    ID = 12,
                    Title = "Visual Basic",
                    Thumbnail = "visualbasic",
                    VideoImagePath = StaticImfo.VideoImagePath + "video_12.jpg",
                    VideoPath = StaticImfo.VideoPath + "video.mp4",
                    Description = "visual basic",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(cat => cat.Name.Equals(".NET")),
                    Url = "www.visulabasic.com"
                };
                context.Videos.Add(video_1);
                context.Videos.Add(video_2);
                context.Videos.Add(video_3);
                context.Videos.Add(video_4);
                context.Videos.Add(video_5);
                context.Videos.Add(video_6);
                context.Videos.Add(video_7);
                context.Videos.Add(video_8);
                context.Videos.Add(video_9);
                context.Videos.Add(video_10);
                context.Videos.Add(video_11);
                context.Videos.Add(video_12);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CreateTags(ApplicationDbContext context)
        {
            try
            {
                // Ebooks Tags
                context.Tags.Add(new Tag()
                {
                    ID = 1,
                    Title = "Ebook_1_Tag_1"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 2,
                    Title = "Ebook_1_Tag_2"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 3,
                    Title = "Ebook_1_Tag_3"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 4,
                    Title = "Ebook_2_Tag_4"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 5,
                    Title = "Ebook_2_Tag_5"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 6,
                    Title = "Ebook_2_Tag_6"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 7,
                    Title = "Ebook_3_Tag_7"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 8,
                    Title = "Ebook_3_Tag_8"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 9,
                    Title = "Ebook_3_Tag_9"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 10,
                    Title = "Ebook_4_Tag_10"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 11,
                    Title = "Ebook_4_Tag_11"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 12,
                    Title = "Ebook_4_Tag_12"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 13,
                    Title = "Ebook_5_Tag_13"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 14,
                    Title = "Ebook_5_Tag_14"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 15,
                    Title = "Ebook_5_Tag_15"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 16,
                    Title = "Ebook_6_Tag_16"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 17,
                    Title = "Ebook_6_Tag_17"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 18,
                    Title = "Ebook_6_Tag_18"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 19,
                    Title = "Ebook_7_Tag_19"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 20,
                    Title = "Ebook_7_Tag_20"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 21,
                    Title = "Ebook_7_Tag_21"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 22,
                    Title = "Ebook_8_Tag_22"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 23,
                    Title = "Ebook_8_Tag_23"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 24,
                    Title = "Ebook_8_Tag_24"
                });
                // Videos Tags
                context.Tags.Add(new Tag()
                {
                    ID = 25,
                    Title = "Video_1_Tag_25"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 26,
                    Title = "Video_1_Tag_26"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 27,
                    Title = "Video_1_Tag_27"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 28,
                    Title = "Video_2_Tag_28"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 29,
                    Title = "Video_2_Tag_29"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 30,
                    Title = "Video_2_Tag_30"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 31,
                    Title = "Video_3_Tag_31"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 32,
                    Title = "Video_3_Tag_32"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 33,
                    Title = "Video_3_Tag_33"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 34,
                    Title = "Video_4_Tag_34"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 35,
                    Title = "Video_4_Tag_35"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 36,
                    Title = "Video_4_Tag_36"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 37,
                    Title = "Video_5_Tag_37"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 38,
                    Title = "Video_5_Tag_38"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 39,
                    Title = "Video_5_Tag_39"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 40,
                    Title = "Video_6_Tag_40"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 41,
                    Title = "Video_6_Tag_41"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 42,
                    Title = "Video_6_Tag_42"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 43,
                    Title = "Video_7_Tag_43"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 44,
                    Title = "Video_7_Tag_44"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 45,
                    Title = "Video_7_Tag_45"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 46,
                    Title = "Video_8_Tag_46"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 47,
                    Title = "Video_8_Tag_47"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 48,
                    Title = "Video_8_Tag_48"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 49,
                    Title = "Video_9_Tag_49"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 50,
                    Title = "Video_9_Tag_50"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 51,
                    Title = "Video_9_Tag_51"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 52,
                    Title = "Video_10_Tag_52"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 53,
                    Title = "Video_10_Tag_53"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 54,
                    Title = "Video_10_Tag_54"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 55,
                    Title = "Video_11_Tag_55"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 56,
                    Title = "Video_11_Tag_56"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 57,
                    Title = "Video_11_Tag_57"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 58,
                    Title = "Video_12_Tag_58"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 59,
                    Title = "Video_12_Tag_59"
                });
                context.Tags.Add(new Tag()
                {
                    ID = 60,
                    Title = "Video_12_Tag_60"
                });
                context.SaveChanges();
                // Ebooks 8
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 1,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 1),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 1)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 2,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 2),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 1)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 3,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 3),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 1)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 4,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 4),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 2)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 5,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 5),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 2)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 6,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 6),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 2)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 7,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 7),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 3)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 8,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 8),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 3)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 9,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 9),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 3)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 10,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 10),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 4)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 11,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 11),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 4)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 12,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 12),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 4)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 13,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 13),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 5)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 14,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 14),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 5)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 15,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 15),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 5)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 16,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 16),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 6)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 17,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 17),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 6)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 18,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 18),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 6)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 19,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 19),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 7)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 20,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 20),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 7)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 21,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 21),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 7)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 22,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 22),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 8)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 23,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 23),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 8)
                });
                context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 24,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 24),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 8)
                });
                // Videos 12
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 1,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 25),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 1)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 2,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 26),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 1)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 3,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 27),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 1)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 4,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 28),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 2)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 5,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 29),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 2)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 6,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 30),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 2)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 7,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 31),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 3)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 8,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 32),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 3)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 9,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 33),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 3)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 10,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 34),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 4)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 11,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 35),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 4)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 12,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 36),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 4)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 13,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 37),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 5)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 14,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 38),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 5)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 15,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 39),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 5)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 16,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 40),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 6)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 17,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 41),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 6)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 18,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 42),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 6)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 19,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 43),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 7)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 20,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 44),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 7)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 21,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 45),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 7)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 22,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 46),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 8)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 23,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 47),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 8)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 24,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 48),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 8)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 25,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 49),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 9)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 26,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 50),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 9)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 27,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 51),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 9)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 28,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 52),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 10)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 29,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 53),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 10)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 30,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 54),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 10)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 31,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 55),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 11)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 32,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 56),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 11)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 33,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 57),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 11)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 34,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 58),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 12)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 35,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 59),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 12)
                });
                context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 36,
                    Tag = context.Tags.FirstOrDefault(t => t.ID == 60),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 12)
                });
                context.SaveChanges();
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
                Random rnd = new Random();
                // Ebooks 
                context.Ratings.Add(new Rating()
                {
                    ID = 1,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 2,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 3,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 4,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 5,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 6,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 7,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 8,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 9,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 10,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 11,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 12,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 13,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 14,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 15,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 16,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 17,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 18,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 19,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 20,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 21,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 22,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 23,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 24,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                // Videos
                context.Ratings.Add(new Rating()
                {
                    ID = 25,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 26,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 27,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 28,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 29,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 30,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 31,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 32,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 33,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 34,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 35,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 36,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 37,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 38,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 39,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 40,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 41,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 42,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 43,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 44,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 45,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 46,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 47,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 48,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 49,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 50,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 51,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 52,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 53,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 54,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 55,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 56,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 57,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 58,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 59,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.Ratings.Add(new Rating()
                {
                    ID = 60,
                    Rate = rnd.Next(0, 6),
                    Rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"))
                });
                context.SaveChanges();
                // Ratings To Ebboks
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 1,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 1),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 1)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 2,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 2),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 1)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 3,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 3),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 1)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 4,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 4),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 2)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 5,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 5),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 2)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 6,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 6),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 2)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 7,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 7),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 3)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 8,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 8),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 3)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 9,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 9),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 3)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 10,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 10),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 4)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 11,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 11),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 4)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 12,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 12),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 4)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 13,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 13),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 5)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 14,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 14),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 5)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 15,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 15),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 5)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 16,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 16),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 6)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 17,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 17),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 6)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 18,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 18),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 6)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 19,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 19),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 7)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 20,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 20),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 7)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 21,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 21),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 7)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 22,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 22),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 8)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 23,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 23),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 8)
                });
                context.RatingsToEbooks.Add(new RatingToEbook()
                {
                    ID = 24,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 24),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 8)
                });
                // Ratings To Videos
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 1,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 25),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 1)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 2,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 26),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 1)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 3,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 27),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 1)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 4,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 28),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 2)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 5,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 29),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 2)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 6,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 30),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 2)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 7,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 31),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 3)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 8,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 32),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 3)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 9,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 33),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 3)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 10,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 34),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 4)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 11,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 35),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 4)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 12,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 36),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 4)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 13,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 37),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 5)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 14,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 38),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 5)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 15,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 39),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 5)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 16,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 40),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 6)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 17,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 41),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 6)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 18,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 42),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 6)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 19,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 43),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 7)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 20,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 44),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 7)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 21,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 45),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 7)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 22,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 46),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 8)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 23,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 47),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 8)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 24,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 48),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 8)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 25,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 49),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 9)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 26,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 50),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 9)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 27,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 51),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 9)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 28,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 52),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 10)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 29,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 53),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 10)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 30,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 54),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 10)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 31,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 55),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 11)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 32,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 56),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 11)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 33,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 57),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 11)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 34,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 58),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 12)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 35,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 59),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 12)
                });
                context.RatingsToVideos.Add(new RatingToVideo()
                {
                    ID = 36,
                    Rating = context.Ratings.FirstOrDefault(r => r.ID == 60),
                    Video = context.Videos.FirstOrDefault(v => v.ID == 12)
                });
                context.SaveChanges();
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
                // Ebooks 
                context.Reviews.Add(new Review()
                {
                    ID = 1,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 2,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 3,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 4,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 5,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 6,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 7,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 8,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 9,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 10,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 11,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 12,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 13,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 14,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 15,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 16,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 17,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 18,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 19,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 20,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 21,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 22,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 23,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 24,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                // Videos
                context.Reviews.Add(new Review()
                {
                    ID = 25,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 26,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 27,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 28,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 29,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 30,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 31,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 32,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 33,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 34,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 35,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 36,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 37,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 38,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 39,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 40,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 41,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 42,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 43,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 44,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 45,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 46,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 47,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 48,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 49,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 50,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 51,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 52,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 53,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 54,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 55,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 56,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 57,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 58,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 59,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.Reviews.Add(new Review()
                {
                    ID = 60,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = "Comment."
                });
                context.SaveChanges();
                // Reviews To Ebooks
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 1,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 1),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 1)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 2,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 2),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 1)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 3,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 3),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 1)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 4,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 4),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 2)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 5,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 5),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 2)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 6,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 6),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 2)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 7,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 7),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 3)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 8,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 8),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 3)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 9,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 9),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 3)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 10,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 10),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 4)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 11,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 11),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 4)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 12,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 12),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 4)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 13,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 13),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 5)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 14,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 14),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 5)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 15,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 15),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 5)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 16,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 16),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 6)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 17,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 17),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 6)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 18,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 18),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 6)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 19,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 19),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 7)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 20,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 20),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 7)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 21,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 21),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 7)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 22,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 22),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 8)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 23,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 23),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 8)
                });
                context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 24,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 24),
                    Ebook = context.Ebooks.FirstOrDefault(e => e.ID == 8)
                });
                // Reviews To Viewos
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 1,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 25),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 1)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 2,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 26),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 1)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 3,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 27),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 1)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 4,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 28),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 2)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 5,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 29),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 2)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 6,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 30),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 2)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 7,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 31),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 3)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 8,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 32),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 3)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 9,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 33),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 3)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 10,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 34),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 4)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 11,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 35),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 4)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 12,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 36),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 4)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 13,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 37),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 5)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 14,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 38),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 5)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 15,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 39),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 5)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 16,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 40),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 6)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 17,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 41),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 6)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 18,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 42),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 6)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 19,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 43),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 7)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 20,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 44),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 7)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 21,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 45),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 7)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 22,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 46),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 8)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 23,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 47),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 8)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 24,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 48),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 8)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 25,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 49),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 9)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 26,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 50),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 9)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 27,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 51),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 9)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 28,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 52),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 10)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 29,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 53),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 10)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 30,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 54),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 10)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 31,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 55),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 11)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 32,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 56),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 11)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 33,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 57),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 11)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 34,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 58),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 12)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 35,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 59),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 12)
                });
                context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 36,
                    Review = context.Reviews.FirstOrDefault(r => r.ID == 60),
                    Video = context.Videos.FirstOrDefault(e => e.ID == 12)
                });
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CreateRequiremenets(ApplicationDbContext context)
        {
            for (int i = 1; i < (21 * 3); i++)
            {
                context.Requirements.Add(
                    new Requirement()
                    {
                        ID = i,
                        Content = $"Requirements {i}"
                    }
                );
            }
            context.SaveChanges();
            var requirements = context.Requirements.ToList();
            var ebooks = context.Ebooks.ToList();
            var videos = context.Videos.ToList();
            int counter = 1;
            foreach (var ebook in ebooks)
            {
                for (int i = 0; i < 3; i++)
                {
                    context.RequirementsToEbooks.Add(
                        new RequirementToEbook()
                        {
                            ID = ebook.ID,
                            Requirement = requirements[counter],
                            Ebook = ebook
                        }
                    );
                    counter++;
                }
            }
            foreach (var video in videos)
            {
                for (int i = 0; i < 3; i++)
                {
                    context.RequirementsToVideos.Add(
                        new RequirementToVideo()
                        {
                            ID = video.ID,
                            Requirement = requirements[counter],
                            Video = video
                        }
                    );
                    counter++;
                }
            }
            context.SaveChanges();
        }
    }
}