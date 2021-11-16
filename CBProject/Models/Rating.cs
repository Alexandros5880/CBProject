namespace CBProject.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public decimal Rate { get; set; }

        public ApplicationUser Rater { get; set; }
    }
}