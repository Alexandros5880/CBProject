using CBProject.Models.EntityModels;
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
        [ForeignKey("Video")]
        public int VideoId { get; set; }
        public Video Video { get; set; }
        [ForeignKey("Ebook")]
        public int EbookId { get; set; }
        public Ebook Ebook { get; set; }
    }
}