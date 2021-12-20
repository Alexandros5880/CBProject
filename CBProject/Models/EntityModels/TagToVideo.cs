namespace CBProject.Models.EntityModels
{
    public class TagToVideo
    {
        public int ID { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int VideoId { get; set; }
        public Video Video { get; set; }
    }
}