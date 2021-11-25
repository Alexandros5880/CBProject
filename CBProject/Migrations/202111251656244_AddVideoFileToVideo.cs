namespace CBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVideoFileToVideo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "VideoPath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "VideoPath");
        }
    }
}
