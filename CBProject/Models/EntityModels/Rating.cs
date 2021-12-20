using CBProject.Models.EntityModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models
{
    public class Rating
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Range(0, 10)]
        public int Rate { get; set; }
        [ForeignKey("Rater")]
        [Required]
        public string RaterId { get; set; }
        public ApplicationUser Rater { get; set; }
        public ICollection<RatingToEbook> RatingsToEbooks { get; set; }
        public ICollection<RatingToVideo> RatingsToVideos { get; set; }
    }
}