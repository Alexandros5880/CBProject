using CBProject.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CBProject.Models.ViewModels
{
    public class VideoViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public HttpPostedFileBase VideoImageFile { get; set; }
        public string VideoImagePath { get; set; }
        public HttpPostedFileBase VideoFile { get; set; }
        public string VideoPath { get; set; }
        public string Description { get; set; }
        public float Rate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UploadDate { get; set; }
        public ApplicationUser Creator { get; set; }
        public string CreatorId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Url { get; set; }
        public ICollection<ApplicationUser> OtherUsers { get; set; }
        public ICollection<Category> OtherCategory { get; set; }
    }
}