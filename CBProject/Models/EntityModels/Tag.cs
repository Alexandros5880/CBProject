using System.ComponentModel.DataAnnotations;

namespace CBProject.Models.EntityModels
{
    public class Tag
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        [Required]
        public string Title { get; set; }
    }
}