using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CBProject.Areas.Forum.Models.EntityModels
{
    public class ForumSabject
    {
        [Key]
        public int ID { get; set; }
        public ICollection<ForumQuestion> Questions { get; set; }
    }
}