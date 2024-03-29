﻿namespace CBProject.Models.ViewModels
{
    public class FilterParams
    {
        public bool Ebooks { get; set; }
        public bool Videos { get; set; }
        public bool LessonsRatings { get; set; }
        public bool CreatedDate { get; set; }
        public string Search { get; set; }
        public int? Page { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SabscriptionPackageId { get; set; }
    }
}