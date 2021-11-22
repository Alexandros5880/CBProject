using System.Data.Entity.ModelConfiguration;

namespace CBProject.Models.Configurations
{
    public class RatingConfig : EntityTypeConfiguration<Rating>
    {
        public RatingConfig()
        {
            Property(r => r.Id).IsRequired();

            Property(r => r.Rate)
                .HasPrecision(5, 2)
                .IsRequired();


            //Relationship


            HasRequired(r => r.Rater);


            HasRequired(r => r.Video)
                .WithMany(v => v.Ratings)
                .HasForeignKey(r => r.VideoId)
                .WillCascadeOnDelete(false);
        }
    }
}