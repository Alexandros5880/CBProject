using CBProject.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Repositories.IdentityRepos.Interfaces
{
    public interface IRolesRepo
    {
        ApplicationRole Get(string id);
        ApplicationRole GetByName(string name);
        ICollection<ApplicationRole> GetAll();
        ICollection<ApplicationRole> GetAllByNames(ICollection<string> names);
        Task<ApplicationRole> GetAsync(string id);
        Task<ApplicationRole> GetByNameAsync(string name);
        Task<ICollection<ApplicationRole>> GetAllAsync();
        Task<ICollection<ApplicationRole>> GetAllByNamesAsync(ICollection<string> names);
        void Add(string name, RoleLevel level);
        void Add(ApplicationRole role);
        Task<IdentityResult> AddAsync(string name, RoleLevel level);
        Task<IdentityResult> AddAsync(ApplicationRole role);
        void Delete(string name);
        Task<IdentityResult> DeleteAsync(string name);
        void Update(string oldName, string newName);
        void Update(ApplicationRole role);
        Task<IdentityResult> UpdateAsync(string oldName, string newName);
        Task<IdentityResult> UpdateAsync(ApplicationRole role);
        IQueryable<ApplicationRole> GetAllQuerable();
    }
}
