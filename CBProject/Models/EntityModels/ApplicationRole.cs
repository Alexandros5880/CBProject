using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBProject.Models.EntityModels
{
    public enum RoleLevel
    {
        SUPERLOW,
        LOW,
        MIDDLE,
        PLUSSFULL,
        FULL
    }

    public class ApplicationRole : IdentityRole
    {
        public RoleLevel Level { get; set; }
    }
}