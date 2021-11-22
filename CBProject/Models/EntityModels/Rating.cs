namespace CBProject.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public decimal Rate { get; set; }

        public ApplicationUser Rater { get; set; } 

        public string RaterId { get; set; }

        public Video Video { get; set; }

        public int VideoId { get; set; }
    }
}