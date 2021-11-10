namespace CBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserContentTypeNoRequared : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "ContentAccess", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ContentAccess", c => c.String(nullable: false));
        }
    }
}
