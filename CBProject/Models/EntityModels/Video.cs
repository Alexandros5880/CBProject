using CBProject.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace CBProject.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        [NotMapped]
        public HttpPostedFileBase VideoImage { get; set; }
        public string VideoPath { get; set; }
        [NotMapped]
        public HttpPostedFileBase VideoFile { get; set; }
        public string Description { get; set; }
        public DateTime UploadDate { get; set; }
        public ApplicationUser ContentCreator { get; set; }
        public string CreatorId { get; set; }
        public Category Category { get; set; } 
        public int CategoryId { get; set; }
        public string Url { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}