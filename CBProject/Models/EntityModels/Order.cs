using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models.EntityModels
{
    public class Order
    {
        public int ID { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey("Package")]
        public int SubscriptionPackageId { get; set; }
        public SubscriptionPackage Package { get; set; }
        public bool IsClose { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsCanceledByError { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
    }
}