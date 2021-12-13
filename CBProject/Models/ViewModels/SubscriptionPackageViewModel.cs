﻿
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
        public bool AutoSubscription { get; set; }
        public DateTime StartDate { get; set; }

        public ICollection<ApplicationUser> MyUsers { get; set; }
        public ICollection<Category> OtherUsers { get; set; }
        public ICollection<string> AddUsers { get; set; }
        public ICollection<string> RemoveUsers { get; set; }

        public ContentType ContentType { get; set; }
        public ICollection<ContentType> MyContentType { get; set; }
        public ICollection<ContentType> OtherContentType { get; set; }
        public ICollection<int> AddContentType { get; set; }
        public ICollection<int> RemoveContentType { get; set; }

        public Payment Payment { get; set; }
        public ICollection<Payment> MyPayment { get; set; }
        public ICollection<Payment> OtherPayment { get; set; }
        public ICollection<int> AddPayment { get; set; }
        public ICollection<int> RemovePayment { get; set; }
    }
}