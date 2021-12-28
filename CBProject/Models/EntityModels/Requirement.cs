using System.ComponentModel.DataAnnotations;

namespace CBProject.Models.EntityModels
{
    public class Requirement
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Content { get; set; }
    }
}