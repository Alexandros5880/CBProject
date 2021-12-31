﻿namespace CBProject.Models.HelperModels
{
    public class OrderApiModel
    {
        public int ID { get; set; }
        public string UserEmail { get; set; }
        public int SubscriptionId { get; set; }
        public bool IsClose { get; set; }
        public decimal Price { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }
    }
}