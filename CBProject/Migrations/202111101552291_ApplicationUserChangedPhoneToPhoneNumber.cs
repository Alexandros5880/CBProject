namespace CBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserChangedPhoneToPhoneNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            DropColumn("dbo.AspNetUsers", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
