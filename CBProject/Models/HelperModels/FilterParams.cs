namespace CBProject.Models.ViewModels
{
    public class FilterParams
    {
        public bool Ebooks { get; set; }
        public bool Videos { get; set; }
        public bool LessonsSequence { get; set; }
        public bool CreatedDate { get; set; }
        public string Search { get; set; }
    }
}