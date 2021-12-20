namespace CBProject.Models.EntityModels
{
    public class ReviewToVideo
    {
        public int ID { get; set; }
        public int ReviewId { get; set; }
        public Review Review { get; set; }
        public int VideoId { get; set; }
        public Video Video { get; set; }
    }
}