
using CBProject.Models.EntityModels;
using System;
using System.Collections.Generic;


namespace CBProject.Models.ViewModels
{
    public class SubscriptionPackageViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Duration { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public ContentType ContentType { get; set; }
        public bool AutoSubscription { get; set; }
        public DateTime StartDate { get; set; }
        public Payment Payment { get; set; }
    }
}