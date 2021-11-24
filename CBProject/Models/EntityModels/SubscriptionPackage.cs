using System.Collections.Generic;

namespace CBProject.Models.EntityModels
{
    public class SubscriptionPackage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Duration { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public ContentType ContentType { get; set; }
        // TODO: Create Module SubscriptionActivite
        // TODO: Filed of SubscriptionActivite field
    }
}