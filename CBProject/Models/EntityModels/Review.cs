﻿using CBProject.Models.EntityModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models
{
    public class Review
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Reviewer")]
        [Required]
        public string ReviewerId { get; set; }
        public ApplicationUser Reviewer { get; set; }
        [MaxLength]
        [Required]
        public string Comment { get; set; }
        public ICollection<ReviewToEbook> ReviewsToEbooks { get; set; }
        public ICollection<ReviewToVideo> ReviewToVideos { get; set; }
    }
}