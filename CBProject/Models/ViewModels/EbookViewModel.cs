using CBProject.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public HttpPostedFileBase EbookImageFile { get; set; }
        public string EbookImagePath { get; set; }
        public HttpPostedFileBase EbookFile { get; set; }
        public string EbookFilePath { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UploadDate { get; set; }
        public int CategoryId { get; set;  }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public SelectList Users { get; set; }
        public Category Category { get; set; }
        public SelectList Categories { get; set; }

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