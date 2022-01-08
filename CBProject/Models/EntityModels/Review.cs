using CBProject.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models
{
    public class Review
    {
        public int ID { get; set; }
        [ForeignKey("Reviewer")]
        public string ReviewerId { get; set; }
        public ApplicationUser Reviewer { get; set; }
        public string Comment { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public ICollection<ReviewToEbook> ReviewsToEbooks { get; set; }
        public ICollection<ReviewToVideo> ReviewToVideos { get; set; }
    }
}