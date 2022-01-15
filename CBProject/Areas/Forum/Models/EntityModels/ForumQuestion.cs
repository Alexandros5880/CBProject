using CBProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Areas.Forum.Models.EntityModels
{
    public class ForumQuestion
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public ForumSabject Subject { get; set; }
        public ICollection<ForumAnswer> Answers { get; set; }
    }
}