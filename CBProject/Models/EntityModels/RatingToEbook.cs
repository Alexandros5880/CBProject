using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models.EntityModels
{
    public class RatingToEbook
    {
        public int ID { get; set; }
        [ForeignKey("Rating")]
        public int RatingId { get; set; }
        public Rating Rating { get; set; }
        [ForeignKey("Ebook")]
        public int EbookId { get; set; }
        public Ebook Ebook { get; set; }
    }
}