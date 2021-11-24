namespace CBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEbooks : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SubcriptionPackages", newName: "SubscriptionPackages");
            RenameColumn(table: "dbo.AspNetUsers", name: "SubcriptionPackage_ID", newName: "SubscriptionPackage_ID");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_SubcriptionPackage_ID", newName: "IX_SubscriptionPackage_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_SubscriptionPackage_ID", newName: "IX_SubcriptionPackage_ID");
            RenameColumn(table: "dbo.AspNetUsers", name: "SubscriptionPackage_ID", newName: "SubcriptionPackage_ID");
            RenameTable(name: "dbo.SubscriptionPackages", newName: "SubcriptionPackages");
        }
    }
}
