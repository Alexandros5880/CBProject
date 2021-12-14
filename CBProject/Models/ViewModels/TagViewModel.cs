using System.Collections.Generic;

namespace CBProject.Models.ViewModels
{
    public class TagViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Video> Videos { get; set; }
        public int VideoId { get; set; }
    }
}