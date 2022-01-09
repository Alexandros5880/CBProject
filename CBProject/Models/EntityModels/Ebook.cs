using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CBProject.Models.EntityModels
{
    public class Ebook
    {
        public int ID { get; set; }
        public string Title{ get; set; }
        public string Description { get; set; }
        public string EbookImagePath { get; set; }
        public string EbookFilePath { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }
        [ForeignKey("Creator")]
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }  
        public Category Category { get; set; }
        public float RatingsAVG { get; set; }
        public virtual ICollection<SubscriptionPackage> SubscriptionPackages { get; set; }
        [NotMapped]
        public bool Subscribed
        {
            get
            {
                return this.SubscriptionPackages.Any();
            }
        }
        public ICollection<TagToEbook> TagsToEbooks { get; set; }
        public ICollection<RatingToEbook> RatingsToEbooks { get; set; }
        public ICollection<ReviewToEbook> ReviewsToEbooks { get; set; }
        public ICollection<RequirementToEbook> RequirementsToEbooks { get; set; }
        public Ebook()
        {
            this.SubscriptionPackages = new HashSet<SubscriptionPackage>();
        }
    }
}
