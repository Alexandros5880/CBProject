using CBProject.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBProject.Models.ViewModels
{
    public class HomeViewModel
    {
        public ICollection<Ebook> Ebooks{ get; set; }
        public ICollection<Video> Videos { get; set; }
        //public ICollection<Plan> Plans { get; set; }
    }
}