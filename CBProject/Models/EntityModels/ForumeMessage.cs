using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models.EntityModels
{
    public class ForumeMessage
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime SendDate { get; set; }
        public string Message { get; set; }
    }
}