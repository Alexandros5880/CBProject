﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models.EntityModels
{
    public class Ebook
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title{ get; set; }
        [Required]
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string EbookImagePath { get; set; }
        public string EbookFilePath { get; set; }
        public string Url { get; set; }
        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }
        [ForeignKey("Creator")]
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }  
        public Category Category { get; set; }
        public ICollection<TagToEbook> TagsToEbooks { get; set; }
        public ICollection<RatingToEbook> RatingsToEbooks { get; set; }
        public ICollection<ReviewToEbook> ReviewsToEbooks { get; set; }
    }
}