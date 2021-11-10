namespace CBProject.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddCvField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CVPath", c => c.String());
            DropColumn("dbo.AspNetUsers", "CV");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CV", c => c.String());
            DropColumn("dbo.AspNetUsers", "CVPath");
        }
    }
}
