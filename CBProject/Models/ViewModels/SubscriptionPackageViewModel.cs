
using CBProject.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CBProject.Models.ViewModels
{
    public class SubscriptionPackageViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Duration { get; set; }
        public bool AutoSubscription { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        public ICollection<ApplicationUser> MyUsers { get; set; }
        public ICollection<ApplicationUser> OtherUsers { get; set; }
        public ICollection<string> AddUsers { get; set; }
        public ICollection<string> RemoveUsers { get; set; }
        public ContentType ContentType { get; set; }
        public ICollection<ContentType> OtherContentType { get; set; }
        public Payment Payment { get; set; }
        public ICollection<Payment> OtherPayments { get; set; }
    }
}