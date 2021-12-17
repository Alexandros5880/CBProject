using CBProject.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CBProject.Repositories.IdentityRepos.Interfaces
{
    public interface IUsersRepo
    {
        ApplicationUser Get(string id);
        Task<ApplicationUser> GetAsync(string id);
        ApplicationUser GetByEmail(string email);
        Task<ApplicationUser> GetByEmailAsync(string email);
        ICollection<string> GetRoles(ApplicationUser user);
        Task<ICollection<string>> GetRolesAsync(ApplicationUser user);
        ICollection<ApplicationUser> GetAll();
        ICollection<ApplicationUser> GetAll(List<string> usernames);
        Task<ICollection<ApplicationUser>> GetAllAsync();
        Task<ICollection<ApplicationUser>> GetAllAsync(List<string> usernames);
        List<ApplicationRole> GetRolesForUser(ApplicationUser user);
        Task<List<ApplicationRole>> GetRolesForUserAsync(ApplicationUser user);
        ICollection<ApplicationUser> GetUsersFromRole(string name);
        Task<ICollection<ApplicationUser>> GetUsersFromRoleAsync(string name);
        void Add(ApplicationUser obj);
        Task<IdentityResult> AddAsync(ApplicationUser obj);
        void Delete(string id);
        Task<int> DeleteAsync(string id);
        void DeleteReal(string id);
        Task<IdentityResult> DeleteRealAsync(string id);
        void FinalDelete(string id);
        Task<IdentityResult> FinalDeleteAsync(string id);
        void RemoveRole(ApplicationUser user, ApplicationRole role);
        void RemoveRoles(ApplicationUser user);
        void AddRole(ApplicationUser user, ApplicationRole role);
        void ChangePassword(string userId, string newPassword);
        Task<Task> ChangePasswordAsync(string userId, string newPassword);
        void Update(ApplicationUser obj);
        Task<int> UpdateAsync(ApplicationUser obj);
    }
}
