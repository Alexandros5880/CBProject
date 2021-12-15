using CBProject.Models.EntityModels;
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
        [ForeignKey("Video")]
        public int VideoId { get; set; }
        public Video Video { get; set; }
        [ForeignKey("Ebook")]
        public int EbookId { get; set; }
        public Ebook Ebook { get; set; }
    }
}