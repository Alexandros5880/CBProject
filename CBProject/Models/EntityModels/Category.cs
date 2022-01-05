using System.Collections.Generic;

namespace CBProject.Models.EntityModels
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryToCategory> CategoriesToCategories { get; set; }
        public bool Master { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Ebook> Ebooks { get; set; }
    }
}