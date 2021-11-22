using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CBProject.Models.EntityModels
{
    public class Category
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Category> Categories { get; set; }
        public bool Master { get; set; }
        public ICollection<Video> Videos { get; internal set; }
    }
}