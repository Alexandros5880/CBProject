using CBProject.Models.EntityModels;
using System.Web.Mvc;

namespace CBProject.Models.ViewModels
{
    public class ReviewViewModel
    {
        public int ID { get; set; }
        public ApplicationUser Reviewer { get; set; }
        public string ReviewerId { get; set; }
        public string Comment { get; set; }
        public SelectList Users { get; set; }
    }
}