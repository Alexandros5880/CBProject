using CBProject.Models;
using System;
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
        [Column(TypeName = "datetime2")]
        public DateTime SendDate { get; set; }
        public string Question { get; set; }
        public ICollection<ForumAnswer> Answers { get; set; }
    }
}