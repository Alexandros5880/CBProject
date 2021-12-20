namespace CBProject.Models.EntityModels
{
    public class TagToEbook
    {
        public int ID { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int EbookId { get; set; }
        public Ebook Ebook { get; set; }
    }
}