using CBProject.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models
{
    public class Video
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(150)]
        [Required]
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string VideoImagePath { get; set; }
        public string VideoPath { get; set; }
        [MaxLength]
        [Required]
        public string Description { get; set; }
        public DateTime UploadDate { get; set; }
        [ForeignKey("Creator")]
        public string CreatorId { get; set; }
        public ApplicationUser Creator  { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Url { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}