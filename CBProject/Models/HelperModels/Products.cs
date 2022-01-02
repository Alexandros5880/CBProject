using CBProject.Models.EntityModels;
using System.Collections.Generic;

namespace CBProject.Models.HelperModels
{
    public class Products
    {
        public ICollection<Video> Videos { get; set; }
        public ICollection<Ebook> Ebooks { get; set; }
        public int EbooksPages { get; set; }
        public int VideosPages { get; set; }
    }
}