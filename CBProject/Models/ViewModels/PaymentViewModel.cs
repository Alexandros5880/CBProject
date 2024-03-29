﻿using CBProject.Models.EntityModels;

namespace CBProject.Models.ViewModels
{
    public class PaymentViewModel
    {
        public int ID { get; set; }
        public ApplicationUser User { get; set; }
        public decimal Price { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }
    }
}