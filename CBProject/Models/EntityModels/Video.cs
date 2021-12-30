using CBProject.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models
{
    public class Video
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string VideoImagePath { get; set; }
        public string VideoPath { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }
        [ForeignKey("Creator")]
        public string CreatorId { get; set; }
        public ApplicationUser Creator  { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Url { get; set; }
        public ICollection<TagToVideo> TagsToVideos { get; set; }
        public ICollection<RatingToVideo> RatingsToVideos { get; set; }
        public ICollection<ReviewToVideo> ReviewToVideos { get; set; }
        public ICollection<RequirementToVideo> RequirementsToVideos { get; set; }
    }
}