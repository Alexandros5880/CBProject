using CBProject.Models;
using CBProject.Models.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Areas.Forum.Models.EntityModels
{
    public class MessengerMessage
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Group")]
        public int GrouId { get; set; }
        public MessengerGroup Group { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}