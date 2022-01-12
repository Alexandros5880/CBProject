using CBProject.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Areas.Forum.Models.EntityModels
{
    public class ForumAnswer
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime SendDate { get; set; }
        public string Answer { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public ForumQuestion Question { get; set; }
    }
}