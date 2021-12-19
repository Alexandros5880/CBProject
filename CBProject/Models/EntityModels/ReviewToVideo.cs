using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models.EntityModels
{
    public class ReviewToVideo
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Review")]
        public int ReviewId { get; set; }
        public Review Review { get; set; }
        [ForeignKey("Video")]
        public int VideoId { get; set; }
        public Video Video { get; set; }
    }
}