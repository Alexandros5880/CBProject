using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models.EntityModels
{
    public class UserSubscriptionPackage
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey("SubscriptionPackage")]
        public int? SubscriptionPackageId { get; set; }
        public SubscriptionPackage SubscriptionPackage { get; set; }
    }
}