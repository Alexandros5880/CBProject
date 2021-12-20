namespace CBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRae : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ratings", "Rate", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ratings", "Rate", c => c.Int(nullable: false));
        }
    }
}
