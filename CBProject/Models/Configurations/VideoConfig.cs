using System.Data.Entity.ModelConfiguration;

namespace CBProject.Models.Configurations
{
    public class VideoConfig : EntityTypeConfiguration<Video>
    {
        public VideoConfig()
        {
            //Properties
            Property(v => v.Id).IsRequired();

            Property(v => v.Title)
                .HasMaxLength(150)
                .IsRequired();

            Property(v => v.Thumbnail).IsOptional();

            Property(v => v.Description)
                .IsMaxLength()
                .IsRequired();

            Property(v => v.UploadDate).IsOptional();

            Property(v => v.Url).IsOptional();

            Property(v=>v.VideoPath).IsRequired();


            //Relationships
            HasRequired(v => v.ContentCreator)
                .WithMany(d => d.Videos)
                .HasForeignKey(d => d.CreatorId)
                .WillCascadeOnDelete(false);

            HasRequired(v => v.Category)
                .WithMany(d => d.Videos)
                .HasForeignKey(d => d.CategoryId);            

            HasMany(v => v.Tags)
                .WithMany(t => t.Videos)                
                .Map(t =>
                {
                    t.ToTable("VideoTags");
                    t.MapLeftKey("VideoId");
                    t.MapRightKey("TagId");
                });

            

            HasMany(v => v.Reviews)
                .WithRequired(r=>r.Video)
                .HasForeignKey(r => r.VideoId)
                .WillCascadeOnDelete(false);

            HasMany(v => v.Ratings)
                .WithRequired(r => r.Video)
                .HasForeignKey(r => r.VideoId)
                .WillCascadeOnDelete(false);

            

            
        }
    }
}