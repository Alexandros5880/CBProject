﻿using CBProject.Models;
using CBProject.Models.EntityModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Areas.Forum.Models.EntityModels
{
    public class ForumSabject
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<ForumQuestion> Questions { get; set; }
    }
}