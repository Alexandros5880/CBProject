using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models
{
    public class Rating
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public decimal Rate { get; set; }
        [ForeignKey("Rater")]
        [Required]
        public string RaterId { get; set; }
        public ApplicationUser Rater { get; set; }
    }
}