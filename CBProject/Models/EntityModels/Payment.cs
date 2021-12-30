using System.ComponentModel.DataAnnotations;

namespace CBProject.Models.EntityModels
{
    public class Payment
    {
        [Key]
        public int ID { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public double Tax { get; set; }
        public double Discount { get; set; }
    }
}