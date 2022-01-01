using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models.EntityModels
{
    public class RatingToVideo
    {
        public int ID { get; set; }
        [ForeignKey("Rating")]
        public int RatingId { get; set; }
        public Rating Rating { get; set; }
        [ForeignKey("Video")]
        public int VideoId { get; set; }
        public Video Video { get; set; }
    }
}