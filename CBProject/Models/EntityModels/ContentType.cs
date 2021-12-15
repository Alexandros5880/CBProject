using System.ComponentModel.DataAnnotations;

namespace CBProject.Models.EntityModels
{
    public class ContentType
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}