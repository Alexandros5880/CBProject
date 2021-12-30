using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models.EntityModels
{
    public class RequirementToVideo
    {
        public int ID { get; set; }
        [ForeignKey("Requirement")]
        public int RequirementId { get; set; }
        public Requirement Requirement { get; set; }
        [ForeignKey("Video")]
        public int VideoId { get; set; }
        public Video Video { get; set; }
    }
}