namespace CBProject.Models.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public ApplicationUser Reviewer { get; set; }
        public string ReviewerId { get; set; }
        public string Comment { get; set; }
        public Video Video { get; set; }
        public int VideoId { get; set; }
    }
}