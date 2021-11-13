namespace CBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSubcriptionPackagesAndContentTypes : DbMigration
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
                "dbo.ContentTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SubcriptionPackages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.Single(nullable: false),
                        ContentType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ContentTypes", t => t.ContentType_ID)
                .Index(t => t.ContentType_ID);
            
            AddColumn("dbo.AspNetUsers", "SubcriptionPackage_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "SubcriptionPackage_ID");
            AddForeignKey("dbo.AspNetUsers", "SubcriptionPackage_ID", "dbo.SubcriptionPackages", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "SubcriptionPackage_ID", "dbo.SubcriptionPackages");
            DropForeignKey("dbo.SubcriptionPackages", "ContentType_ID", "dbo.ContentTypes");
            DropForeignKey("dbo.Categories", "Category_ID", "dbo.Categories");
            DropIndex("dbo.AspNetUsers", new[] { "SubcriptionPackage_ID" });
            DropIndex("dbo.SubcriptionPackages", new[] { "ContentType_ID" });
            DropIndex("dbo.Categories", new[] { "Category_ID" });
            DropColumn("dbo.AspNetUsers", "SubcriptionPackage_ID");
            DropTable("dbo.SubcriptionPackages");
            DropTable("dbo.ContentTypes");
            DropTable("dbo.Categories");
        }
    }
}
