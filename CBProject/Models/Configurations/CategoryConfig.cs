using CBProject.Models.EntityModels;
using System.Data.Entity.ModelConfiguration;

namespace CBProject.Models.Configurations
{
    public class CategoryConfig : EntityTypeConfiguration<Category>
    {
        public CategoryConfig() //TODO: Category Config
        {
            //Property(c => c.Id).IsRequired();

            //Property(c => c.Title)
            //    .HasMaxLength(200)
            //    .IsRequired();

            ////Relationships

            //HasMany(c => c.Videos)
            //    .WithRequired(v => v.Category)
            //    .HasForeignKey(v => v.CategoryId)
            //    .WillCascadeOnDelete(false);
        }
    }
}