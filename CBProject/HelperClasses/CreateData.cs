﻿using CBProject.Models;
using CBProject.Models.EntityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
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
                    IsInactive = false
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
                    IsInactive = false
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
                    IsInactive = false
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
                    IsInactive = false
                };
                var user_5 = new ApplicationUser()
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
                    IsInactive = false
                };

                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                manager.Create(user_1, user_1.Password);
                manager.Create(user_2, user_2.Password);
                manager.Create(user_3, user_3.Password);
                manager.Create(user_4, user_4.Password);
                manager.Create(user_5, user_5.Password);

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
            }catch (Exception ex)
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
                    Name = "CORE",
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
    }
}