using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models.EntityModels
{
    public class ReviewToEbook
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Review")]
        public int ReviewId { get; set; }
        public Review Review { get; set; }
        [ForeignKey("Ebook")]
        public int EbookId { get; set; }
        public Ebook Ebook { get; set; }
    }
}