using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models.EntityModels
{
    public class RequirementToEbook
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Requirement")]
        public int RequirementId { get; set; }
        public Requirement Requirement { get; set; }
        [ForeignKey("Ebook")]
        public int EbookId { get; set; }
        public Ebook Ebook { get; set; }
    }
}