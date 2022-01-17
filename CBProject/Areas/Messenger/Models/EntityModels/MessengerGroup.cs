using CBProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Areas.Forum.Models.EntityModels
{
    public class MessengerGroup
    {
        public MessengerGroup()
        {
            this.Users = new HashSet<ApplicationUser>();
        }
        [Key]
        public int ID { get; set; }
        [ForeignKey("Creator")]
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public ICollection<MessengerMessage> Messages { get; set; }
    }
}