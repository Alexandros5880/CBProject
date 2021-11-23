namespace CBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEbookEntity : DbMigration
    {
        public override void Up()
        {
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
                        ContentCreator_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ContentCreator_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.ContentCreator_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ebooks", "ContentCreator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ebooks", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Ebooks", new[] { "ContentCreator_Id" });
            DropIndex("dbo.Ebooks", new[] { "CategoryId" });
            DropTable("dbo.Ebooks");
        }
    }
}
