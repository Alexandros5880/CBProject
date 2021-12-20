namespace CBProject.Models.EntityModels
{
    public class RatingToVideo
    {
        public int ID { get; set; }
        public int RatingId { get; set; }
        public Rating Rating { get; set; }
        public int VideoId { get; set; }
        public Video Video { get; set; }
    }
}