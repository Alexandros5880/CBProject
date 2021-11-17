namespace CBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyInitialTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Thumbnail = c.String(),
                        Description = c.String(nullable: false),
                        UploadDate = c.DateTime(),
                        CreatorId = c.String(nullable: false, maxLength: 128),
                        CategoryId = c.Int(nullable: false),
                        Url = c.String(),
                        TagId = c.Int(),
                        ReviewId = c.Int(),
                        RatingId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CreatorId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Decimal(nullable: false, precision: 5, scale: 2),
                        RaterId = c.String(nullable: false, maxLength: 128),
                        VideoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RaterId, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.VideoId)
                .Index(t => t.RaterId)
                .Index(t => t.VideoId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReviewerId = c.String(nullable: false, maxLength: 128),
                        Comment = c.String(nullable: false),
                        VideoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ReviewerId, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.VideoId)
                .Index(t => t.ReviewerId)
                .Index(t => t.VideoId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        VideoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropForeignKey("dbo.Videos", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.VideoTags", "TagId", "dbo.Videos");
            DropForeignKey("dbo.VideoTags", "VideoId", "dbo.Tags");
            DropForeignKey("dbo.Reviews", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.Reviews", "ReviewerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.Ratings", "RaterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Videos", "CreatorId", "dbo.AspNetUsers");
            DropIndex("dbo.VideoTags", new[] { "TagId" });
            DropIndex("dbo.VideoTags", new[] { "VideoId" });
            DropIndex("dbo.Reviews", new[] { "VideoId" });
            DropIndex("dbo.Reviews", new[] { "ReviewerId" });
            DropIndex("dbo.Ratings", new[] { "VideoId" });
            DropIndex("dbo.Ratings", new[] { "RaterId" });
            DropIndex("dbo.Videos", new[] { "CategoryId" });
            DropIndex("dbo.Videos", new[] { "CreatorId" });
            DropTable("dbo.VideoTags");
            DropTable("dbo.Tags");
            DropTable("dbo.Reviews");
            DropTable("dbo.Ratings");
            DropTable("dbo.Videos");
            DropTable("dbo.Categories");
        }
    }
}
