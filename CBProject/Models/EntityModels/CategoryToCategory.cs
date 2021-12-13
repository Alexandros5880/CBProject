using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models.EntityModels
{
    public class CategoryToCategory
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("MasterCategory")]
        public int MasterCategoryId { get; set; }
        public Category MasterCategory { get; set; }

        [ForeignKey("ChiledCategory")]
        public int ChiledCategoryId { get; set; }
        public Category ChiledCategory { get; set; }
    }
}