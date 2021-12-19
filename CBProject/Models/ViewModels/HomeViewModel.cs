using CBProject.Models.EntityModels;
using System.Collections.Generic;

namespace CBProject.Models.ViewModels
{
    public class HomeViewModel
    {
        public ICollection<Ebook> Ebooks{ get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Category> Categories { get; set; }
        //public ICollection<Plan> Plans { get; set; }
    }
}