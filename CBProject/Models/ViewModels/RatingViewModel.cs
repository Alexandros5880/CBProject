using CBProject.Models.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CBProject.Models.ViewModels
{
    public class RatingViewModel
    {
        public int ID { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "Please select number between 1 and 5")]
        public int Rate { get; set; }
        public ApplicationUser Rater { get; set; }
        public string RaterId { get; set; }
        public SelectList Users { get; set; }
    }
}