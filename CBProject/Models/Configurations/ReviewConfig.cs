using System.Data.Entity.ModelConfiguration;

namespace CBProject.Models.Configurations
{
    public class ReviewConfig : EntityTypeConfiguration<Review>
    {
        public ReviewConfig()
        {
            Property(r => r.Id).IsRequired();

            Property(r => r.Comment)
                .IsMaxLength()
                .IsRequired();


            //Relationship
            HasRequired(r => r.Reviewer);

            HasRequired(r => r.Video)
                .WithMany(v => v.Reviews)
                .HasForeignKey(v => v.VideoId)
                .WillCascadeOnDelete(false);

        }
    }
}