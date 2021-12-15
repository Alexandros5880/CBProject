using System.ComponentModel.DataAnnotations;

namespace CBProject.Models.EntityModels
{
    public enum PaymentMethods
    {
        BankTransfer,
        Paypal,
        DebitCard
    }
    public class Payment
    {
        [Key]
        public int ID { get; set; }
        public PaymentMethods PaymentMethods { get; set; }
        public ApplicationUser User { get; set; }
        public decimal Price { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }

    }
}