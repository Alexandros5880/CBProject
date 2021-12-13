using CBProject.Models.EntityModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CBProject.Models.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Category> OtherCategories { get; set; }
        public ICollection<Category> MyCategories { get; set; }
        public ICollection<int> AddCategories { get; set; }
        public ICollection<int> RemoveCategories { get; set; }
        public bool Master { get; set; }
        public ICollection<Video> OtherVideos { get; set; }
        public ICollection<Video> MyVideos { get; set; }
        public ICollection<int> AddVideos { get; set; }
        public ICollection<int> RemoveVideos { get; set; }
    }
}