using CBProject.Models.EntityModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models
{
    public class Rating
    {
        public int ID { get; set; }
        [Range(0, 5)]
        public float Rate { get; set; }
        [ForeignKey("Rater")]
        public string RaterId { get; set; }
        public ApplicationUser Rater { get; set; }
        public ICollection<RatingToEbook> RatingsToEbooks { get; set; }
        public ICollection<RatingToVideo> RatingsToVideos { get; set; }
    }
}