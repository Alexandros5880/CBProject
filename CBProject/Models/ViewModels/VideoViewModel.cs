using CBProject.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Web;

namespace CBProject.Models.ViewModels
{
    public class VideoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public HttpPostedFileBase VideoImage { get; set; }
        public string VideoPath { get; set; }
        public HttpPostedFileBase VideoFile { get; set; }
        public string Description { get; set; }
        public DateTime UploadDate { get; set; }
        public ApplicationUser ContentCreator { get; set; }
        public string CreatorId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Url { get; set; }


        public ICollection<Tag> Tags { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Rating> Ratings { get; set; }


        public ICollection<Tag> OtherTags { get; set; }
        public ICollection<Tag> MyTags { get; set; }
        public ICollection<int> AddTags { get; set; }
        public ICollection<int> RemoveTags { get; set; }

        public ICollection<Review> OtherReviews { get; set; }
        public ICollection<Review> MyReviews { get; set; }
        public ICollection<int> AddReviews { get; set; }
        public ICollection<int> RemoveReviews { get; set; }

        public ICollection<Rating> OtherRatings { get; set; }
        public ICollection<Rating> MyRatings { get; set; }
        public ICollection<int> AddRatings { get; set; }
        public ICollection<int> RemoveRatings { get; set; }

    }
}