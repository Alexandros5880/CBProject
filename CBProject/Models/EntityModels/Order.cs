using System;
using System.ComponentModel.DataAnnotations;

namespace CBProject.Models.EntityModels
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        public SubscriptionPackage SubscriptionPackage { get; set; }
        [Required]
        public bool IsClose { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime LastUpdatedDate { get; set; }
    }
}