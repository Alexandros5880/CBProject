namespace CBProject.Migrations
{
    using CBProject.Areas.Forum.HelperClasses;
    using CBProject.Areas.Messenger.HelperClasses;
    using CBProject.HelperClassesm;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CBProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CBProject.Models.ApplicationDbContext context)
        {
            CreateData.CreateAll(context);
            CreateForumsTestData.CreateAll(context);
            CreateMessengerTestData.CreateAll(context);
        }
    }
}
