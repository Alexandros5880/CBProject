using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CBProject.Models.EntityModels
{
    public class SubscriptionPackage
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Duration { get; set; }
        public ICollection<ApplicationUser> MyUsers { get; set; }
        public ContentType ContentType { get; set; }
        public bool AutoSubscription { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        public Payment Payment { get; set; }
    }
}