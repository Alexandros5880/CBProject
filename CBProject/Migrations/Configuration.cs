namespace CBProject.Migrations
{
    using CBProject.HelperClasses;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CBProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CBProject.Models.ApplicationDbContext context)
        {
            var createData = new CreateData(context);
            createData.CreateUsersAndRoles();
            createData.CreateCategories();
            createData.CreateSubscriptionPackages();
            createData.CreateEbook();
            createData.CreateVideo();
            createData.CreateTags();
            createData.CreateRating();
            createData.CreateReview();
            createData.CreateRequiremenets();
            //createData.Dispose();
        }
    }
}
