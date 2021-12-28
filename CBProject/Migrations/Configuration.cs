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
            CreateData.CreateUsersAndRoles(context);
            CreateData.CreateCategories(context);
            CreateData.CreateContentTypes(context);
            CreateData.CreatePayments(context);
            CreateData.CreateSubscriptionPackages(context);
            CreateData.CreateEbook(context);
            CreateData.CreateVideo(context);
            CreateData.CreateTags(context);
            CreateData.CreateRating(context);
            CreateData.CreateReview(context);
            CreateData.CreateRequiremenets(context);
        }
    }
}
