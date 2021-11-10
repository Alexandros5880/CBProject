namespace CBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFieldFromNumberToStreetNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "StreetNumber", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Number", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "StreetNumber");
        }
    }
}
