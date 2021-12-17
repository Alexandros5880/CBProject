using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CBProject.Models.ViewModels
{
    public class IdentityRoleViewModel
    {
        public virtual ICollection<ApplicationUser> Users { get; }
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public RoleLevel Level { get; set; }
    }
}