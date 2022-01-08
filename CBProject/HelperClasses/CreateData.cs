using CBProject.Models;
using CBProject.Models.EntityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CBProject.HelperClasses
{
    public class CreateData : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _unitOfWork;
        public CreateData(ApplicationDbContext context)
        {
            this._context = context;
            this._unitOfWork = new UnitOfWork(context);
        }
        public void CreateUsersAndRoles()
        {
            try
            {
                if (!this._context.Roles.Any(r => r.Name == "Admin"))
                {
                    var store_1 = new RoleStore<ApplicationRole>(this._context);
                    var manager_1 = new RoleManager<ApplicationRole>(store_1);
                    var role_1 = new ApplicationRole { Name = "Admin", Level = RoleLevel.FULL };
                    manager_1.Create(role_1);
                }
                if (!this._context.Roles.Any(r => r.Name == "Manager"))
                {
                    var store_2 = new RoleStore<ApplicationRole>(this._context);
                    var manager_2 = new RoleManager<ApplicationRole>(store_2);
                    var role_2 = new ApplicationRole { Name = "Manager", Level = RoleLevel.PLUSSFULL };
                    manager_2.Create(role_2);
                }
                if (!this._context.Roles.Any(r => r.Name == "Teacher"))
                {
                    var store_3 = new RoleStore<ApplicationRole>(this._context);
                    var manager_3 = new RoleManager<ApplicationRole>(store_3);
                    var role_3 = new ApplicationRole { Name = "Teacher", Level = RoleLevel.MIDDLE };
                    manager_3.Create(role_3);
                }
                if (!this._context.Roles.Any(r => r.Name == "Student"))
                {
                    var store_4 = new RoleStore<ApplicationRole>(this._context);
                    var manager_4 = new RoleManager<ApplicationRole>(store_4);
                    var role_4 = new ApplicationRole { Name = "Student", Level = RoleLevel.LOW };
                    manager_4.Create(role_4);
                }
                if (!this._context.Roles.Any(r => r.Name == "Guest"))
                {
                    var store_5 = new RoleStore<ApplicationRole>(this._context);
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

                var store = new UserStore<ApplicationUser, ApplicationRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>(this._context);
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
        public void CreateCategories()
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
                this._context.Categories.Add(category1);
                this._context.Categories.Add(category2);
                this._context.Categories.Add(category3);
                this._context.Categories.Add(category4);
                this._context.Categories.Add(category5);
                this._context.Categories.Add(category6);

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
                this._context.CategoriesToCategories.Add(catToCat1);
                this._context.CategoriesToCategories.Add(catToCat2);
                this._context.CategoriesToCategories.Add(catToCat3);
                this._context.CategoriesToCategories.Add(catToCat4);
                this._context.CategoriesToCategories.Add(catToCat5);
                this._context.CategoriesToCategories.Add(catToCat6);

                this._context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CreateSubscriptionPackages()
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
                        this._context.Users.FirstOrDefault()
                    },
                    AutoSubscription = true,
                    StartDate = DateTime.Today
                };
                SubscriptionPackage package2 = new SubscriptionPackage()
                {
                    ID = 2,
                    Description = "Advance",
                    Price = 100,
                    Duration = 23.33f,
                    MyUsers = new List<ApplicationUser>()
                    {
                        this._context.Users.FirstOrDefault()
                    },
                    AutoSubscription = true,
                    StartDate = DateTime.Today
                };
                SubscriptionPackage package3 = new SubscriptionPackage()
                {
                    ID = 3,
                    Description = "Premium",
                    Price = 100,
                    Duration = 23.33f,
                    MyUsers = new List<ApplicationUser>()
                    {
                        this._context.Users.FirstOrDefault()
                    },
                    AutoSubscription = true,
                    StartDate = DateTime.Today
                };
                this._context.SubcriptionPackages.Add(package1);
                this._context.SubcriptionPackages.Add(package2);
                this._context.SubcriptionPackages.Add(package3);
                this._context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CreateEbook()
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
                    EbookFilePath = StaticImfo.EbooksFilesPath + "Group_Project.pdf",
                    Url = "url",
                    UploadDate = DateTime.Today,
                    Creator = this._context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = this._context.Categories.FirstOrDefault(c => c.Name.Equals(".NET"))
                };
                Ebook ebook2 = new Ebook()
                {
                    ID = 2,
                    Title = "ASP.NET Core 5",
                    Description = "ASP.NET Core 5 for Beginners: Kick-start your ASP.NET web development journey with the help of step-by-step tutorials and examples",
                    Thumbnail = "Thubnail",
                    EbookImagePath = StaticImfo.EbooksImagesPath + "ebook_2.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + "Group_Project.pdf",
                    Url = "url",
                    UploadDate = DateTime.Today,
                    Creator = this._context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = this._context.Categories.FirstOrDefault(c => c.Name.Equals("CORE"))
                };
                Ebook ebook3 = new Ebook()
                {
                    ID = 3,
                    Title = "Xamarin UI Development",
                    Description = "Mastering Xamarin UI Development",
                    Thumbnail = "Thubnail",
                    EbookImagePath = StaticImfo.EbooksImagesPath + "ebook_3.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + "Group_Project.pdf",
                    Url = "url",
                    UploadDate = DateTime.Today,
                    Creator = this._context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = this._context.Categories.FirstOrDefault(c => c.Name.Equals("XAMARIN"))
                };
                Ebook ebook4 = new Ebook()
                {
                    ID = 4,
                    Title = "C++",
                    Description = "FIFTH EDITION",
                    Thumbnail = "Thubnail",
                    EbookImagePath = StaticImfo.EbooksImagesPath + "ebook_4.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + "Group_Project.pdf",
                    Url = "url",
                    UploadDate = DateTime.Today,
                    Creator = this._context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = this._context.Categories.FirstOrDefault(c => c.Name.Equals(".NET"))
                };
                Ebook ebook5 = new Ebook()
                {
                    ID = 5,
                    Title = "Development Of Windows",
                    Description = "The Development Of Windows Presentation Foundation: Basics And Must-Know Information: Wpf Development On Linux",
                    Thumbnail = "Thubnail",
                    EbookImagePath = StaticImfo.EbooksImagesPath + "ebook_5.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + "Group_Project.pdf",
                    Url = "url",
                    UploadDate = DateTime.Today,
                    Creator = this._context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = this._context.Categories.FirstOrDefault(c => c.Name.Equals("CORE"))
                };
                Ebook ebook6 = new Ebook()
                {
                    ID = 6,
                    Title = "MVC",
                    Description = "Cros Platform Framework. (Windows, Linux, Mac, IOS)",
                    Thumbnail = "Thubnail",
                    EbookImagePath = StaticImfo.EbooksImagesPath + "ebook_6.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + "Group_Project.pdf",
                    Url = "url",
                    UploadDate = DateTime.Today,
                    Creator = this._context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = this._context.Categories.FirstOrDefault(c => c.Name.Equals("FRAMEWORK"))
                };
                Ebook ebook7 = new Ebook()
                {
                    ID = 7,
                    Title = "Microservices with .Net Core",
                    Description = "Architect your .NET applications by breaking them into really small pieces - microservices - using this practical, example-based guide",
                    Thumbnail = "Thubnail",
                    EbookImagePath = StaticImfo.EbooksImagesPath + "ebook_7.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + "Group_Project.pdf",
                    Url = "url",
                    UploadDate = DateTime.Today,
                    Creator = this._context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = this._context.Categories.FirstOrDefault(c => c.Name.Equals("CORE"))
                };
                Ebook ebook8 = new Ebook()
                {
                    ID = 8,
                    Title = "EntityFramework",
                    Description = "Cros Platform Framework. (Windows, Linux, Mac, IOS)",
                    Thumbnail = "Thubnail",
                    EbookImagePath = StaticImfo.EbooksImagesPath + "ebook_8.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + "Group_Project.pdf",
                    Url = "url",
                    UploadDate = DateTime.Today,
                    Creator = this._context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = this._context.Categories.FirstOrDefault(c => c.Name.Equals("FRAMEWORK"))
                };
                this._context.Ebooks.Add(ebook1);
                this._context.Ebooks.Add(ebook2);
                this._context.Ebooks.Add(ebook3);
                this._context.Ebooks.Add(ebook4);
                this._context.Ebooks.Add(ebook5);
                this._context.Ebooks.Add(ebook6);
                this._context.Ebooks.Add(ebook7);
                this._context.Ebooks.Add(ebook8);
                this._context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CreateVideo()
        {
            Random random = new Random();
            for (int i = 1; i < 13; i++)
            {
                var videoAbsolutePath = $"{StaticImfo.CurrentPath}\\{StaticImfo.VideoFilesFolder}\\video{i}.mp4";
                var thumbnailAbsolutePath = $"{StaticImfo.CurrentPath}\\{StaticImfo.VideoImagePath}video_{i}_thambnail.jpg";
                string thumbnailPath = $"{StaticImfo.VideoImagePath}video_{i}_thambnail.jpg";
                VideoEditor.CreateThambnail(videoAbsolutePath, thumbnailAbsolutePath, 1);
                var duration = VideoEditor.Duration(videoAbsolutePath);
                int categoryId = random.Next(0, 6);
                this._context.Videos.Add(new Video()
                {
                    ID = i,
                    Title = $"MVC_EP_{i}",
                    Thumbnail = thumbnailPath,
                    VideoImagePath = StaticImfo.VideoImagePath + $"video_{i}.jpg",
                    VideoPath = StaticImfo.VideoPath + $"video{i}.mp4",
                    Description = $"mvc_ep_{i}",
                    UploadDate = DateTime.Today,
                    Duration = duration,
                    Creator = this._context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = this._context.Categories.FirstOrDefault(c => c.ID == categoryId),
                    Url = $"www.mvc_ep_{i}.com"
                });
            }
            this._context.SaveChanges();
            try
            {
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CreateTags()
        {
            try
            {
                // Ebooks Tags
                this._context.Tags.Add(new Tag()
                {
                    ID = 1,
                    Title = "Ebook_1_Tag_1"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 2,
                    Title = "Ebook_1_Tag_2"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 3,
                    Title = "Ebook_1_Tag_3"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 4,
                    Title = "Ebook_2_Tag_4"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 5,
                    Title = "Ebook_2_Tag_5"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 6,
                    Title = "Ebook_2_Tag_6"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 7,
                    Title = "Ebook_3_Tag_7"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 8,
                    Title = "Ebook_3_Tag_8"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 9,
                    Title = "Ebook_3_Tag_9"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 10,
                    Title = "Ebook_4_Tag_10"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 11,
                    Title = "Ebook_4_Tag_11"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 12,
                    Title = "Ebook_4_Tag_12"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 13,
                    Title = "Ebook_5_Tag_13"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 14,
                    Title = "Ebook_5_Tag_14"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 15,
                    Title = "Ebook_5_Tag_15"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 16,
                    Title = "Ebook_6_Tag_16"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 17,
                    Title = "Ebook_6_Tag_17"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 18,
                    Title = "Ebook_6_Tag_18"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 19,
                    Title = "Ebook_7_Tag_19"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 20,
                    Title = "Ebook_7_Tag_20"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 21,
                    Title = "Ebook_7_Tag_21"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 22,
                    Title = "Ebook_8_Tag_22"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 23,
                    Title = "Ebook_8_Tag_23"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 24,
                    Title = "Ebook_8_Tag_24"
                });
                // Videos Tags
                this._context.Tags.Add(new Tag()
                {
                    ID = 25,
                    Title = "Video_1_Tag_25"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 26,
                    Title = "Video_1_Tag_26"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 27,
                    Title = "Video_1_Tag_27"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 28,
                    Title = "Video_2_Tag_28"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 29,
                    Title = "Video_2_Tag_29"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 30,
                    Title = "Video_2_Tag_30"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 31,
                    Title = "Video_3_Tag_31"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 32,
                    Title = "Video_3_Tag_32"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 33,
                    Title = "Video_3_Tag_33"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 34,
                    Title = "Video_4_Tag_34"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 35,
                    Title = "Video_4_Tag_35"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 36,
                    Title = "Video_4_Tag_36"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 37,
                    Title = "Video_5_Tag_37"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 38,
                    Title = "Video_5_Tag_38"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 39,
                    Title = "Video_5_Tag_39"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 40,
                    Title = "Video_6_Tag_40"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 41,
                    Title = "Video_6_Tag_41"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 42,
                    Title = "Video_6_Tag_42"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 43,
                    Title = "Video_7_Tag_43"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 44,
                    Title = "Video_7_Tag_44"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 45,
                    Title = "Video_7_Tag_45"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 46,
                    Title = "Video_8_Tag_46"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 47,
                    Title = "Video_8_Tag_47"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 48,
                    Title = "Video_8_Tag_48"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 49,
                    Title = "Video_9_Tag_49"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 50,
                    Title = "Video_9_Tag_50"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 51,
                    Title = "Video_9_Tag_51"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 52,
                    Title = "Video_10_Tag_52"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 53,
                    Title = "Video_10_Tag_53"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 54,
                    Title = "Video_10_Tag_54"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 55,
                    Title = "Video_11_Tag_55"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 56,
                    Title = "Video_11_Tag_56"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 57,
                    Title = "Video_11_Tag_57"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 58,
                    Title = "Video_12_Tag_58"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 59,
                    Title = "Video_12_Tag_59"
                });
                this._context.Tags.Add(new Tag()
                {
                    ID = 60,
                    Title = "Video_12_Tag_60"
                });
                this._context.SaveChanges();
                // Ebooks 8
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 1,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 1),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 1)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 2,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 2),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 1)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 3,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 3),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 1)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 4,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 4),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 2)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 5,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 5),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 2)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 6,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 6),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 2)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 7,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 7),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 3)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 8,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 8),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 3)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 9,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 9),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 3)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 10,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 10),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 4)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 11,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 11),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 4)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 12,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 12),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 4)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 13,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 13),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 5)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 14,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 14),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 5)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 15,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 15),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 5)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 16,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 16),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 6)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 17,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 17),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 6)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 18,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 18),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 6)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 19,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 19),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 7)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 20,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 20),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 7)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 21,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 21),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 7)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 22,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 22),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 8)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 23,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 23),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 8)
                });
                this._context.TagsToEbooks.Add(new TagToEbook()
                {
                    ID = 24,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 24),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 8)
                });
                // Videos 12
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 1,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 25),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 1)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 2,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 26),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 1)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 3,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 27),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 1)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 4,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 28),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 2)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 5,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 29),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 2)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 6,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 30),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 2)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 7,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 31),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 3)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 8,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 32),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 3)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 9,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 33),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 3)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 10,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 34),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 4)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 11,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 35),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 4)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 12,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 36),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 4)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 13,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 37),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 5)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 14,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 38),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 5)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 15,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 39),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 5)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 16,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 40),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 6)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 17,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 41),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 6)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 18,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 42),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 6)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 19,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 43),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 7)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 20,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 44),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 7)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 21,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 45),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 7)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 22,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 46),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 8)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 23,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 47),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 8)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 24,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 48),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 8)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 25,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 49),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 9)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 26,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 50),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 9)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 27,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 51),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 9)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 28,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 52),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 10)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 29,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 53),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 10)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 30,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 54),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 10)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 31,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 55),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 11)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 32,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 56),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 11)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 33,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 57),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 11)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 34,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 58),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 12)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 35,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 59),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 12)
                });
                this._context.TagsToVideos.Add(new TagToVideo()
                {
                    ID = 36,
                    Tag = this._context.Tags.FirstOrDefault(t => t.ID == 60),
                    Video = this._context.Videos.FirstOrDefault(v => v.ID == 12)
                });
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CreateRating()
        {
            var ratingRepo = this._unitOfWork.Ratings;
            var ebooksRepo = this._unitOfWork.Ebooks;
            var videosRepo = this._unitOfWork.Videos;
            var rater = this._context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"));
            Random rnd = new Random();
            // Ebooks
            for (int? i = 1; i < 8; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ebooksRepo.AddRating(i, rater.Id, rnd.Next(0, 6));
                }
            }
            // Videos
            for (int? i = 1; i < 12; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    videosRepo.AddRating(i, rater.Id, rnd.Next(0, 6));
                }
            }
        }
        public void CreateReview()
        {
            try
            {
                for (int i = 1; i < 61; i++)
                {
                    this._context.Reviews.Add(new Review()
                    {
                        ID = i,
                        Reviewer = this._context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                        Comment = "Comment.",
                        CreatedDate = DateTime.Now
                    }); ;
                }
                this._context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            try
            {
                // Reviews To Ebooks
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 1,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 1),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 1)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 2,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 2),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 1)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 3,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 3),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 1)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 4,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 4),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 2)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 5,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 5),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 2)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 6,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 6),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 2)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 7,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 7),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 3)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 8,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 8),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 3)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 9,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 9),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 3)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 10,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 10),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 4)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 11,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 11),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 4)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 12,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 12),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 4)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 13,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 13),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 5)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 14,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 14),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 5)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 15,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 15),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 5)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 16,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 16),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 6)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 17,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 17),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 6)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 18,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 18),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 6)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 19,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 19),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 7)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 20,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 20),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 7)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 21,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 21),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 7)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 22,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 22),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 8)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 23,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 23),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 8)
                });
                this._context.ReviewsToEbooks.Add(new ReviewToEbook()
                {
                    ID = 24,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 24),
                    Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == 8)
                });
                // Reviews To Viewos
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 1,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 25),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 1)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 2,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 26),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 1)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 3,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 27),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 1)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 4,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 28),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 2)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 5,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 29),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 2)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 6,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 30),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 2)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 7,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 31),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 3)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 8,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 32),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 3)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 9,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 33),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 3)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 10,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 34),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 4)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 11,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 35),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 4)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 12,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 36),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 4)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 13,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 37),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 5)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 14,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 38),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 5)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 15,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 39),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 5)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 16,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 40),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 6)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 17,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 41),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 6)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 18,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 42),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 6)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 19,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 43),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 7)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 20,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 44),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 7)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 21,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 45),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 7)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 22,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 46),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 8)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 23,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 47),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 8)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 24,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 48),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 8)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 25,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 49),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 9)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 26,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 50),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 9)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 27,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 51),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 9)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 28,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 52),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 10)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 29,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 53),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 10)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 30,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 54),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 10)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 31,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 55),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 11)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 32,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 56),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 11)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 33,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 57),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 11)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 34,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 58),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 12)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 35,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 59),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 12)
                });
                this._context.ReviewsToVideos.Add(new ReviewToVideo()
                {
                    ID = 36,
                    Review = this._context.Reviews.FirstOrDefault(r => r.ID == 60),
                    Video = this._context.Videos.FirstOrDefault(e => e.ID == 12)
                });
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CreateRequiremenets()
        {
            for(int i = 1; i < (21*3); i++)
            {
                this._context.Requirements.Add(
                    new Requirement()
                    {
                        ID = i,
                        Content = $"Requirements {i}"
                    }
                );
            }
            this._context.SaveChanges();
            var requirements = this._context.Requirements.ToList();
            var ebooks = this._context.Ebooks.ToList();
            var videos = this._context.Videos.ToList();
            int counter = 1;
            foreach (var ebook in ebooks)
            {
                for(int i = 0; i < 3; i++)
                {
                    this._context.RequirementsToEbooks.Add(
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
                    this._context.RequirementsToVideos.Add(
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
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
            this._unitOfWork.Dispose();
        }
    }
}