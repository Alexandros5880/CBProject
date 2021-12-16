using System.Web.Mvc;

namespace CBProject.Models.ViewModels
{
    public class TagViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public SelectList Videos { get; set; }
        public int VideoId { get; set; }
        public SelectList Ebooks { get; set; }
        public int EbookId { get; set; }
    }
}