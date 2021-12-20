namespace CBProject.Models.EntityModels
{
    public class RatingToEbook
    {
        public int ID { get; set; }
        public int RatingId { get; set; }
        public Rating Rating { get; set; }
        public int EbookId { get; set; }
        public Ebook Ebook { get; set; }
    }
}