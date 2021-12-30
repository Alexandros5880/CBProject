using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models.EntityModels
{
    public class Payment
    {
        public int ID { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public decimal Price { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }
    }
}