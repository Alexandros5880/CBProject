using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CBProject.Models.Configurations
{
    public class ContentTypeConfiguration : EntityTypeConfiguration<ContentType>
    {
        public ContentTypeConfiguration()
        {
            //Property
            Property(t => t.Id).IsRequired();

            Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();


            //Relationships

            
        }
        
    }
}