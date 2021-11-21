using System.Collections.Generic;

namespace CBProject.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}