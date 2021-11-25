namespace CBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start : DbMigration
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
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Thumbnail = c.String(),
                        VideoPath = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        UploadDate = c.DateTime(),
                        CreatorId = c.String(nullable: false, maxLength: 128),
                        CategoryId = c.Int(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id)
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
                        SubscriptionId = c.Int(nullable: false),
                        ContentAccess = c.String(),
                        CVPath = c.String(),
                        ContentCategoryId = c.Int(nullable: false),
                        ContentId = c.Int(nullable: false),
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
                "dbo.Payments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PaymentMethods = c.Int(nullable: false),
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
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Decimal(nullable: false, precision: 5, scale: 2),
                        RaterId = c.String(nullable: false, maxLength: 128),
                        VideoId = c.Int(nullable: false),
                        Ebook_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RaterId, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.VideoId)
                .ForeignKey("dbo.Ebooks", t => t.Ebook_ID)
                .Index(t => t.RaterId)
                .Index(t => t.VideoId)
                .Index(t => t.Ebook_ID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReviewerId = c.String(nullable: false, maxLength: 128),
                        Comment = c.String(nullable: false),
                        VideoId = c.Int(nullable: false),
                        Ebook_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ReviewerId, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.VideoId)
                .ForeignKey("dbo.Ebooks", t => t.Ebook_ID)
                .Index(t => t.ReviewerId)
                .Index(t => t.VideoId)
                .Index(t => t.Ebook_ID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        VideoId = c.Int(nullable: false),
                        Ebook_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ebooks", t => t.Ebook_ID)
                .Index(t => t.Ebook_ID);
            
            CreateTable(
                "dbo.ContentTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ebooks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        Url = c.String(),
                        UploadDate = c.DateTime(nullable: false),
                        CreatorId = c.String(),
                        CategoryId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                        ReviewId = c.Int(nullable: false),
                        RatingId = c.Int(nullable: false),
                        ContentCreator_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ContentCreator_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.ContentCreator_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.SubscriptionPackages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.Single(nullable: false),
                        AutoSubscription = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        ContentType_ID = c.Int(),
                        Payment_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ContentTypes", t => t.ContentType_ID)
                .ForeignKey("dbo.Payments", t => t.Payment_ID)
                .Index(t => t.ContentType_ID)
                .Index(t => t.Payment_ID);
            
            CreateTable(
                "dbo.VideoTags",
                c => new
                    {
                        VideoId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VideoId, t.TagId })
                .ForeignKey("dbo.Tags", t => t.VideoId, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.TagId, cascadeDelete: true)
                .Index(t => t.VideoId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "SubscriptionPackage_ID", "dbo.SubscriptionPackages");
            DropForeignKey("dbo.SubscriptionPackages", "Payment_ID", "dbo.Payments");
            DropForeignKey("dbo.SubscriptionPackages", "ContentType_ID", "dbo.ContentTypes");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Tags", "Ebook_ID", "dbo.Ebooks");
            DropForeignKey("dbo.Reviews", "Ebook_ID", "dbo.Ebooks");
            DropForeignKey("dbo.Ratings", "Ebook_ID", "dbo.Ebooks");
            DropForeignKey("dbo.Ebooks", "ContentCreator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ebooks", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.VideoTags", "TagId", "dbo.Videos");
            DropForeignKey("dbo.VideoTags", "VideoId", "dbo.Tags");
            DropForeignKey("dbo.Reviews", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.Reviews", "ReviewerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.Ratings", "RaterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Videos", "CreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Payments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Videos", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Category_ID", "dbo.Categories");
            DropIndex("dbo.VideoTags", new[] { "TagId" });
            DropIndex("dbo.VideoTags", new[] { "VideoId" });
            DropIndex("dbo.SubscriptionPackages", new[] { "Payment_ID" });
            DropIndex("dbo.SubscriptionPackages", new[] { "ContentType_ID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Ebooks", new[] { "ContentCreator_Id" });
            DropIndex("dbo.Ebooks", new[] { "CategoryId" });
            DropIndex("dbo.Tags", new[] { "Ebook_ID" });
            DropIndex("dbo.Reviews", new[] { "Ebook_ID" });
            DropIndex("dbo.Reviews", new[] { "VideoId" });
            DropIndex("dbo.Reviews", new[] { "ReviewerId" });
            DropIndex("dbo.Ratings", new[] { "Ebook_ID" });
            DropIndex("dbo.Ratings", new[] { "VideoId" });
            DropIndex("dbo.Ratings", new[] { "RaterId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Payments", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "SubscriptionPackage_ID" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Videos", new[] { "CategoryId" });
            DropIndex("dbo.Videos", new[] { "CreatorId" });
            DropIndex("dbo.Categories", new[] { "Category_ID" });
            DropTable("dbo.VideoTags");
            DropTable("dbo.SubscriptionPackages");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Ebooks");
            DropTable("dbo.ContentTypes");
            DropTable("dbo.Tags");
            DropTable("dbo.Reviews");
            DropTable("dbo.Ratings");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Payments");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Videos");
            DropTable("dbo.Categories");
        }
    }
}
