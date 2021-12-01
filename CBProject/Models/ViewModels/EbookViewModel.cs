﻿using CBProject.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CBProject.Models.ViewModels
{
    public class EbookViewModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Thumbnail { get; set; }

        public string Url { get; set; }

        public DateTime UploadDate { get; set; }

        public int CategoryId { get; set;  }

        public Category Category { get; set; }

        public SelectList Categories { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Rating> Ratings { get; set; }

     


    }
}