using System.Collections.Generic;

namespace CBProject.Models.EntityModels
{
    public class Tag
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public ICollection<TagToEbook> TagsToEbooks { get; set; }
        public ICollection<TagToVideo> TagsToVideos { get; set; }
    }
}