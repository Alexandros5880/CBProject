using CBProject.Models.EntityModels;
using System.Collections.Generic;

namespace CBProject.Models.ViewModels
{
    public class HomeViewModel
    {
        public ICollection<EbookViewModel> Ebooks{ get; set; }
        public ICollection<VideoViewModel> Videos { get; set; }
        public ICollection<Category> Categories { get; set; }
        //public ICollection<Plan> Plans { get; set; }
        public string Search { get; set; }
    }
}