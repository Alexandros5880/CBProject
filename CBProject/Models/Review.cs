namespace CBProject.Models
{
    public class Review
    {
        public int Id { get; set; }

        public ApplicationUser Reviewer { get; set; }

        public string Comment { get; set; }
    }
}