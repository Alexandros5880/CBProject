using System.Data.Entity.ModelConfiguration;

namespace CBProject.Models.Configurations
{
    public class TagConfig : EntityTypeConfiguration<Tag>
    {
        public TagConfig()
        {
            Property(t => t.Id).IsRequired();

            Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();


            HasMany(r => r.Videos)
                .WithMany(r => r.Tags)
                .Map(t =>
                {
                    t.ToTable("VideoTags");
                    t.MapLeftKey("VideoId");
                    t.MapRightKey("TagId");
                });




        }
    }
}