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
        public ICollection<Category> Categories { get; set; }
        public bool Master { get; set; }
        public ICollection<Video> Videos { get; internal set; }
    }
}