namespace CBProject.Models.EntityModels
{
    public class ReviewToEbook
    {
        public int ID { get; set; }
        public int ReviewId { get; set; }
        public Review Review { get; set; }
        public int EbookId { get; set; }
        public Ebook Ebook { get; set; }
    }
}