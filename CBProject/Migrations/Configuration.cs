namespace CBProject.Migrations
{
    using CBProject.Areas.Forum.HelperClasses;
    using CBProject.HelperClassesm;
    using System.Data.Entity.Migrations;

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
        }
    }
}
