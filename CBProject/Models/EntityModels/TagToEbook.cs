using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models.EntityModels
{
    public class TagToEbook
    {
        public int ID { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        [ForeignKey("Ebook")]
        public int EbookId { get; set; }
        public Ebook Ebook { get; set; }
    }
}