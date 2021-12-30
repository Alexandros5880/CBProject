namespace CBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initiasl1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Master = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CategoryToCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MasterCategoryId = c.Int(nullable: false),
                        ChiledCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.ChiledCategoryId)
                .ForeignKey("dbo.Categories", t => t.MasterCategoryId, cascadeDelete: true)
                .Index(t => t.MasterCategoryId)
                .Index(t => t.ChiledCategoryId);
            
            CreateTable(
                "dbo.Ebooks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Thumbnail = c.String(),
                        EbookImagePath = c.String(),
                        EbookFilePath = c.String(),
                        Url = c.String(),
                        Content = c.String(),
                        UploadDate = c.DateTime(nullable: false),
                        CreatorId = c.String(maxLength: 128),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .Index(t => t.CreatorId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BirthDate = c.DateTime(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        State = c.String(nullable: false),
                        City = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        StreetNumber = c.String(nullable: false),
                        CreditCardNum = c.String(),
                        ContentAccess = c.String(),
                        CVPath = c.String(),
                        ImagePath = c.String(),
                        NewsletterAcception = c.Boolean(nullable: false),
                        IsInactive = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        SubscriptionPackage_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubscriptionPackages", t => t.SubscriptionPackage_ID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.SubscriptionPackage_ID);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsClose = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        SubscriptionPackage_ID = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubscriptionPackages", t => t.SubscriptionPackage_ID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.SubscriptionPackage_ID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.SubscriptionPackages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.Single(nullable: false),
                        AutoSubscription = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        ContentType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ContentTypes", t => t.ContentType_ID)
                .Index(t => t.ContentType_ID);
            
            CreateTable(
                "dbo.ContentTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Thumbnail = c.String(),
                        VideoImagePath = c.String(),
                        VideoPath = c.String(),
                        Content = c.String(),
                        Description = c.String(nullable: false),
                        UploadDate = c.DateTime(nullable: false),
                        CreatorId = c.String(maxLength: 128),
                        CategoryId = c.Int(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .Index(t => t.CreatorId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.RatingToVideos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RatingId = c.Int(nullable: false),
                        VideoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ratings", t => t.RatingId, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: true)
                .Index(t => t.RatingId)
                .Index(t => t.VideoId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Rate = c.Single(nullable: false),
                        RaterId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.RaterId, cascadeDelete: true)
                .Index(t => t.RaterId);
            
            CreateTable(
                "dbo.RatingToEbooks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RatingId = c.Int(nullable: false),
                        EbookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ebooks", t => t.EbookId, cascadeDelete: true)
                .ForeignKey("dbo.Ratings", t => t.RatingId, cascadeDelete: true)
                .Index(t => t.RatingId)
                .Index(t => t.EbookId);
            
            CreateTable(
                "dbo.RequirementToVideos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RequirementId = c.Int(nullable: false),
                        VideoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Requirements", t => t.RequirementId, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: true)
                .Index(t => t.RequirementId)
                .Index(t => t.VideoId);
            
            CreateTable(
                "dbo.Requirements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReviewToVideos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReviewId = c.Int(nullable: false),
                        VideoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Reviews", t => t.ReviewId, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: true)
                .Index(t => t.ReviewId)
                .Index(t => t.VideoId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReviewerId = c.String(nullable: false, maxLength: 128),
                        Comment = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ReviewerId, cascadeDelete: true)
                .Index(t => t.ReviewerId);
            
            CreateTable(
                "dbo.ReviewToEbooks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReviewId = c.Int(nullable: false),
                        EbookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ebooks", t => t.EbookId, cascadeDelete: true)
                .ForeignKey("dbo.Reviews", t => t.ReviewId, cascadeDelete: true)
                .Index(t => t.ReviewId)
                .Index(t => t.EbookId);
            
            CreateTable(
                "dbo.TagToVideos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        VideoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.VideoId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TagToEbooks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        EbookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ebooks", t => t.EbookId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.EbookId);
            
            CreateTable(
                "dbo.RequirementToEbooks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RequirementId = c.Int(nullable: false),
                        EbookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ebooks", t => t.EbookId, cascadeDelete: true)
                .ForeignKey("dbo.Requirements", t => t.RequirementId, cascadeDelete: true)
                .Index(t => t.RequirementId)
                .Index(t => t.EbookId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Level = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RequirementToEbooks", "RequirementId", "dbo.Requirements");
            DropForeignKey("dbo.RequirementToEbooks", "EbookId", "dbo.Ebooks");
            DropForeignKey("dbo.Ebooks", "CreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TagToVideos", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.TagToVideos", "TagId", "dbo.Tags");
            DropForeignKey("dbo.TagToEbooks", "TagId", "dbo.Tags");
            DropForeignKey("dbo.TagToEbooks", "EbookId", "dbo.Ebooks");
            DropForeignKey("dbo.ReviewToVideos", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.ReviewToVideos", "ReviewId", "dbo.Reviews");
            DropForeignKey("dbo.ReviewToEbooks", "ReviewId", "dbo.Reviews");
            DropForeignKey("dbo.ReviewToEbooks", "EbookId", "dbo.Ebooks");
            DropForeignKey("dbo.Reviews", "ReviewerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RequirementToVideos", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.RequirementToVideos", "RequirementId", "dbo.Requirements");
            DropForeignKey("dbo.RatingToVideos", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.RatingToVideos", "RatingId", "dbo.Ratings");
            DropForeignKey("dbo.RatingToEbooks", "RatingId", "dbo.Ratings");
            DropForeignKey("dbo.RatingToEbooks", "EbookId", "dbo.Ebooks");
            DropForeignKey("dbo.Ratings", "RaterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Videos", "CreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Videos", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Payments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "SubscriptionPackage_ID", "dbo.SubscriptionPackages");
            DropForeignKey("dbo.AspNetUsers", "SubscriptionPackage_ID", "dbo.SubscriptionPackages");
            DropForeignKey("dbo.SubscriptionPackages", "ContentType_ID", "dbo.ContentTypes");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ebooks", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategoryToCategories", "MasterCategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategoryToCategories", "ChiledCategoryId", "dbo.Categories");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RequirementToEbooks", new[] { "EbookId" });
            DropIndex("dbo.RequirementToEbooks", new[] { "RequirementId" });
            DropIndex("dbo.TagToEbooks", new[] { "EbookId" });
            DropIndex("dbo.TagToEbooks", new[] { "TagId" });
            DropIndex("dbo.TagToVideos", new[] { "VideoId" });
            DropIndex("dbo.TagToVideos", new[] { "TagId" });
            DropIndex("dbo.ReviewToEbooks", new[] { "EbookId" });
            DropIndex("dbo.ReviewToEbooks", new[] { "ReviewId" });
            DropIndex("dbo.Reviews", new[] { "ReviewerId" });
            DropIndex("dbo.ReviewToVideos", new[] { "VideoId" });
            DropIndex("dbo.ReviewToVideos", new[] { "ReviewId" });
            DropIndex("dbo.RequirementToVideos", new[] { "VideoId" });
            DropIndex("dbo.RequirementToVideos", new[] { "RequirementId" });
            DropIndex("dbo.RatingToEbooks", new[] { "EbookId" });
            DropIndex("dbo.RatingToEbooks", new[] { "RatingId" });
            DropIndex("dbo.Ratings", new[] { "RaterId" });
            DropIndex("dbo.RatingToVideos", new[] { "VideoId" });
            DropIndex("dbo.RatingToVideos", new[] { "RatingId" });
            DropIndex("dbo.Videos", new[] { "CategoryId" });
            DropIndex("dbo.Videos", new[] { "CreatorId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Payments", new[] { "User_Id" });
            DropIndex("dbo.SubscriptionPackages", new[] { "ContentType_ID" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "SubscriptionPackage_ID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "SubscriptionPackage_ID" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Ebooks", new[] { "CategoryId" });
            DropIndex("dbo.Ebooks", new[] { "CreatorId" });
            DropIndex("dbo.CategoryToCategories", new[] { "ChiledCategoryId" });
            DropIndex("dbo.CategoryToCategories", new[] { "MasterCategoryId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RequirementToEbooks");
            DropTable("dbo.TagToEbooks");
            DropTable("dbo.Tags");
            DropTable("dbo.TagToVideos");
            DropTable("dbo.ReviewToEbooks");
            DropTable("dbo.Reviews");
            DropTable("dbo.ReviewToVideos");
            DropTable("dbo.Requirements");
            DropTable("dbo.RequirementToVideos");
            DropTable("dbo.RatingToEbooks");
            DropTable("dbo.Ratings");
            DropTable("dbo.RatingToVideos");
            DropTable("dbo.Videos");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Payments");
            DropTable("dbo.ContentTypes");
            DropTable("dbo.SubscriptionPackages");
            DropTable("dbo.Orders");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Ebooks");
            DropTable("dbo.CategoryToCategories");
            DropTable("dbo.Categories");
        }
    }
}
