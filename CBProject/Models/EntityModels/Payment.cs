using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBProject.Models.EntityModel
{
    public enum PaymentMethods
    {
        BankTransfer,
        Paypal,
        DebitCard
    }
    public class Payment
    {
        public int ID { get; set; }
        public PaymentMethods PaymentMethods { get; set; }
        public ApplicationUser User { get; set; }
        public decimal Price { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }

    }
}