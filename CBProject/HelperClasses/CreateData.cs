using CBProject.HelperClasses;
using CBProject.Models;
using CBProject.Models.EntityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CBProject.HelperClassesm
{
    public static class CreateData
    {
        public static void CreateUsersAndRoles(ApplicationDbContext context)
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
        public static void CreateSubscriptionPackages(ApplicationDbContext context)
        {
            SubscriptionPackage package1 = new SubscriptionPackage()
            {
                ID = 1,
                Description = "Basic",
                Price = 33,
                Duration = 23.33f,
                MyUsers = new List<ApplicationUser>()
                    {
                        context.Users.FirstOrDefault()
                    },
                AutoSubscription = true,
                StartDate = DateTime.Today
            };
            SubscriptionPackage package2 = new SubscriptionPackage()
            {
                ID = 2,
                Description = "Advance",
                Price = 77,
                Duration = 23.33f,
                MyUsers = new List<ApplicationUser>()
                    {
                        context.Users.FirstOrDefault()
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
                        context.Users.FirstOrDefault()
                    },
                AutoSubscription = true,
                StartDate = DateTime.Today
            };
            context.SubcriptionPackages.Add(package1);
            context.SubcriptionPackages.Add(package2);
            context.SubcriptionPackages.Add(package3);
            context.SaveChanges();
        }
        public static void CreateEbook(ApplicationDbContext context)
        {
            Random random = new Random();
            for (int i = 1; i < 26; i++)
            {
                int categoryId = random.Next(4, 7);
                context.Ebooks.Add(new Ebook()
                {
                    ID = i,
                    Title = $"Ebook {i}",
                    Description = $"Ebook {i} Description",
                    EbookImagePath = StaticImfo.EbooksImagesPath + $"ebook{i}.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + $"ebook{i}.pdf",
                    Url = $"www.ebook{i}.com",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(c => c.Master == false && c.ID == categoryId),
                });
            }
            context.SaveChanges();
        }
        public static void CreateVideo(ApplicationDbContext context)
        {
            Random random = new Random();
            for (int i = 1; i < 26; i++)
            {
                var videoAbsolutePath = $"{StaticImfo.CurrentPath}\\{StaticImfo.VideoFilesFolder}\\video{i}.mp4";
                var thumbnailAbsolutePath = $"{StaticImfo.CurrentPath}\\{StaticImfo.VideoImagePath}video_{i}_thambnail.jpg";
                string thumbnailPath = $"{StaticImfo.VideoImagePath}video_{i}_thambnail.jpg";
                VideoEditor.CreateThambnail(videoAbsolutePath, thumbnailAbsolutePath, 1);
                var duration = VideoEditor.Duration(videoAbsolutePath);
                int categoryId = random.Next(4, 7);
                context.Videos.Add(new Video()
                {
                    ID = i,
                    Title = $"Video {i}",
                    Thumbnail = thumbnailPath,
                    VideoImagePath = StaticImfo.VideoImagePath + $"video{i}.jpg",
                    VideoPath = StaticImfo.VideoPath + $"video{i}.mp4",
                    Description = $"Video {i}",
                    UploadDate = DateTime.Today,
                    Duration = duration,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(c => c.Master == false && c.ID == categoryId),
                    Url = $"www.video{i}.com"
                });
            }
            context.SaveChanges();
        }
        public static void CreateTags(ApplicationDbContext context)
        {
            // Add Tags
            for (int i = 1; i < 151; i++)
            {
                context.Tags.Add(new Tag()
                {
                    ID = i,
                    Title = $"Tag_{i}"
                });
            }
            context.SaveChanges();
            // Tag to Ebook
            int tag_id = 1;
            int id = 1;
            foreach(var ebook in context.Ebooks)
            {
                for(int i = 1; i <= 3; i++)
                {
                    context.TagsToEbooks.Add(new TagToEbook()
                    {
                        ID = id,
                        TagId = tag_id,
                        EbookId = ebook.ID,
                    });
                    id++;
                    tag_id++;
                }
            }
            context.SaveChanges();
            // Tag To Video
            id = 1;
            foreach (var video in context.Videos)
            {
                for (int i = 1; i <= 3; i++)
                {
                    context.TagsToVideos.Add(new TagToVideo()
                    {
                        ID = id,
                        TagId = tag_id,
                        VideoId = video.ID
                    });
                    id++;
                    tag_id++;
                }
            }
            context.SaveChanges();
        }
        public static void CreateRating(ApplicationDbContext context)
        {
            var unitOfWork = new UnitOfWork(context);
            var ratingRepo = unitOfWork.Ratings;
            var ebooksRepo = unitOfWork.Ebooks;
            var videosRepo = unitOfWork.Videos;
            var rater = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3"));
            Random rnd = new Random();
            // Ebooks
            for (int? i = 1; i < 26; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ebooksRepo.AddRating(i, rater.Id, rnd.Next(1, 6));
                }
            }
            // Videos
            for (int? i = 1; i < 26; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    videosRepo.AddRating(i, rater.Id, rnd.Next(1, 6));
                }
            }
        }
        public static void CreateReview(ApplicationDbContext context)
        {
            for (int i = 1; i < 151; i++)
            {
                context.Reviews.Add(new Review()
                {
                    ID = i,
                    Reviewer = context.Users.FirstOrDefault(u => u.FirstName.Equals("Alexandros_3")),
                    Comment = $"Comment {i}",
                    CreatedDate = DateTime.Now
                }); ;
            }
            context.SaveChanges();
            // Review to Ebook
            int review_id = 1;
            int id = 1;
            foreach (var ebook in context.Ebooks)
            {
                for (int i = 1; i <= 3; i++)
                {
                    context.ReviewsToEbooks.Add(new ReviewToEbook()
                    {
                        ID = id,
                        ReviewId = review_id,
                        EbookId = ebook.ID,
                    });
                    id++;
                    review_id++;
                }
            }
            context.SaveChanges();
            // Review to Video
            id = 1;
            foreach (var video in context.Videos)
            {
                for (int i = 1; i <= 3; i++)
                {
                    context.ReviewsToVideos.Add(new ReviewToVideo()
                    {
                        ID = id,
                        ReviewId = review_id,
                        VideoId = video.ID,
                    });
                    id++;
                    review_id++;
                }
            }
            context.SaveChanges();
        }
        public static void CreateRequiremenets(ApplicationDbContext context)
        {
            for(int i = 1; i < 151; i++)
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
            int requirementId = 1;
            int id = 1;
            foreach (var ebook in context.Ebooks)
            {
                for(int i = 0; i < 3; i++)
                {
                    context.RequirementsToEbooks.Add(
                        new RequirementToEbook()
                        {
                            ID = id,
                            RequirementId = requirementId,
                            EbookId = ebook.ID
                        }
                    );
                    id++;
                    requirementId++;
                }
            }
            id = 1;
            foreach (var video in context.Videos)
            {
                for (int i = 0; i < 3; i++)
                {
                    context.RequirementsToVideos.Add(
                        new RequirementToVideo()
                        {
                            ID = id,
                            RequirementId = requirementId,
                            VideoId = video.ID
                        }
                    );
                    id++;
                    requirementId++;
                }
            }
            context.SaveChanges();
        }
        public static void CreateSubscriptionWithEbooksAndVideos(ApplicationDbContext context)
        {
            // make 15 ebooks/videos private five for every package
            int ebookId = 1;
            int videoId = 1;
            foreach (var package in context.SubcriptionPackages.ToList())
            {
                for (int i = 1; i <= 5; i++)
                {
                    package.Ebooks.Add(context.Ebooks.FirstOrDefault(e => e.ID == ebookId));
                    ebookId++;
                }
                for (int i = 1; i <= 5; i++)
                {
                    package.Videos.Add(context.Videos.FirstOrDefault(v => v.ID == videoId));
                    videoId++;
                }
                context.Entry(package).State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChanges();
        }
        public static void CreateMoreTestDataFree(ApplicationDbContext context)
        {
            // Create Ebooks
            Random random = new Random();
            for (int i = 26; i < 35; i++)
            {
                int categoryId = random.Next(4, 7);
                context.Ebooks.Add(new Ebook()
                {
                    ID = i,
                    Title = $"Ebook {i}",
                    Description = $"Ebook {i} Description",
                    EbookImagePath = StaticImfo.EbooksImagesPath + $"ebook{i}.jpg",
                    EbookFilePath = StaticImfo.EbooksFilesPath + $"ebook{i}.pdf",
                    Url = $"www.ebook{i}.com",
                    UploadDate = DateTime.Today,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(c => c.Master == false && c.ID == categoryId),
                });
            }
            context.SaveChanges();
            // Create Videos
            for (int i = 26; i < 35; i++)
            {
                var videoAbsolutePath = $"{StaticImfo.CurrentPath}\\{StaticImfo.VideoFilesFolder}\\video{i}.mp4";
                var thumbnailAbsolutePath = $"{StaticImfo.CurrentPath}\\{StaticImfo.VideoImagePath}video_{i}_thambnail.jpg";
                string thumbnailPath = $"{StaticImfo.VideoImagePath}video_{i}_thambnail.jpg";
                VideoEditor.CreateThambnail(videoAbsolutePath, thumbnailAbsolutePath, 1);
                var duration = VideoEditor.Duration(videoAbsolutePath);
                int categoryId = random.Next(4, 7);
                context.Videos.Add(new Video()
                {
                    ID = i,
                    Title = $"Video {i}",
                    Thumbnail = thumbnailPath,
                    VideoImagePath = StaticImfo.VideoImagePath + $"video{i}.jpg",
                    VideoPath = StaticImfo.VideoPath + $"video{i}.mp4",
                    Description = $"Video {i}",
                    UploadDate = DateTime.Today,
                    Duration = duration,
                    Creator = context.Users.FirstOrDefault(user => user.FirstName.Equals("Alexandros_3")),
                    Category = context.Categories.FirstOrDefault(c => c.Master == false && c.ID == categoryId),
                    Url = $"www.video{i}.com"
                });
            }
            context.SaveChanges();
        }

        public static void CreateAll(ApplicationDbContext context)
        {
            CreateUsersAndRoles(context);
            CreateCategories(context);
            CreateSubscriptionPackages(context);
            CreateEbook(context);
            CreateVideo(context);
            CreateTags(context);
            CreateRating(context);
            CreateReview(context);
            CreateRequiremenets(context);
            CreateSubscriptionWithEbooksAndVideos(context);
            CreateMoreTestDataFree(context);
        }
    }
}