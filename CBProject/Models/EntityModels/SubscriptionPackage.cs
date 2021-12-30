using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CBProject.Models.EntityModels
{
    public class SubscriptionPackage
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Duration { get; set; }
        public ICollection<ApplicationUser> MyUsers { get; set; }
        public ICollection<Order> Orders { get; set; }
        public bool AutoSubscription { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
    }
}