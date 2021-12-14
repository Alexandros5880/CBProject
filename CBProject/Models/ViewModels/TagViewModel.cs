using System.Web.Mvc;

namespace CBProject.Models.ViewModels
{
    public class TagViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public SelectList Videos { get; set; }
        public int VideoId { get; set; }
    }
}