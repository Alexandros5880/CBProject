using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
    }
}