using CBProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CBProject.Repositories.IdentityRepos.Interfaces
{
    public interface IUsersRepo
    {
        ApplicationUser Get(string id);
        Task<ApplicationUser> GetAsync(string id);
        ICollection<string> GetRoles(ApplicationUser user);
        Task<ICollection<string>> GetRolesAsync(ApplicationUser user);
        ICollection<ApplicationUser> GetAll();
        ICollection<ApplicationUser> GetAll(List<string> usernames);
        Task<ICollection<ApplicationUser>> GetAllAsync();
        Task<ICollection<ApplicationUser>> GetAllAsync(List<string> usernames);
        List<string> GetRolesForUser(ApplicationUser user);
        Task<List<string>> GetRolesForUserAsync(ApplicationUser user);
        ICollection<ApplicationUser> GetUsersFromRole(string name);
        Task<ICollection<ApplicationUser>> GetUsersFromRoleAsync(string name);
        void Add(ApplicationUser obj);
        Task<IdentityResult> AddAsync(ApplicationUser obj);
        void Delete(string id);
        Task<IdentityResult> DeleteAsync(string id);
        void RemoveRole(ApplicationUser user, IdentityRole role);
        void AddRole(ApplicationUser user, IdentityRole role);
        void Update(ApplicationUser obj);
        Task<IdentityResult> UpdateAsync(ApplicationUser obj);
    }
}
