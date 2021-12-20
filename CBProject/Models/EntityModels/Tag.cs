using System.Collections.Generic;
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
        public ICollection<TagToEbook> TagsToEbooks { get; set; }
        public ICollection<TagToVideo> TagsToVideos { get; set; }
    }
}