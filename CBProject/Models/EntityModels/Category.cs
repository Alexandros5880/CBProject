using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CBProject.Models.EntityModels
{
    public class Category
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<CategoryToCategory> CategoriesToCategories { get; set; }
        public bool Master { get; set; }
        public ICollection<Video> Videos { get; internal set; }
        public ICollection<Ebook> Ebooks { get; internal set; }
    }
}