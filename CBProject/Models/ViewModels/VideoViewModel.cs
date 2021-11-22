using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBProject.Models.ViewModels
{
    public class VideoViewModel
    {
        public Video Video { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}