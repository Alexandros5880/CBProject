﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBProject.Models.EntityModels
{
    public class Ebook
    {
        public int ID { get; set; }

        public string Title{ get; set; }

        public string Description { get; set; }

        public string Thumbnail { get; set; }

        public string Url { get; set; }

        public DateTime UploadDate { get; set; }

        public ApplicationUser ContentCreator { get; set; }
        public string CreatorId { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }
        //public ICollection<Tag> Tags { get; set; }

        ////public int TagId { get; set; }

        //public ICollection<Review> Reviews { get; set; }

        //// public int ReviewId { get; set; }

        //public ICollection<Rating> Ratings { get; set; }

        // public int RatingId { get; set; }

    }
}