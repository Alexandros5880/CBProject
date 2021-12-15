﻿using System.Web.Mvc;

namespace CBProject.Models.ViewModels
{
    public class RatingViewModel
    {
        public int ID { get; set; }
        public decimal Rate { get; set; }
        public ApplicationUser Rater { get; set; }
        public string RaterId { get; set; }
        public Video Video { get; set; }
        public int VideoId { get; set; }
        public SelectList Users { get; set; }
        public SelectList Videos { get; set; }
    }
}