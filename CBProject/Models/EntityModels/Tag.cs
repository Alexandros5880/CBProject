using System.Collections.Generic;

namespace CBProject.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Video> Videos { get; set; }
        public int VideoId { get; set; }
    }
}