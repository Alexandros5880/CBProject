using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CBProject.Repositories.IdentityRepos.Interfaces
{
    public interface IRolesRepo
    {
        IdentityRole Get(string id);
        IdentityRole GetByName(string name);
        ICollection<IdentityRole> GetAll();
        ICollection<IdentityRole> GetAllByNames(ICollection<string> names);
        Task<IdentityRole> GetAsync(string id);
        Task<IdentityRole> GetByNameAsync(string name);
        Task<ICollection<IdentityRole>> GetAllAsync();
        Task<ICollection<IdentityRole>> GetAllByNamesAsync(ICollection<string> names);
        void Add(string name);
        void Add(IdentityRole role);
        Task<IdentityResult> AddAsync(string name);
        Task<IdentityResult> AddAsync(IdentityRole role);
        void Delete(string name);
        Task<IdentityResult> DeleteAsync(string name);
        void Update(string oldName, string newName);
        void Update(IdentityRole role);
        Task<IdentityResult> UpdateAsync(string oldName, string newName);
        Task<IdentityResult> UpdateAsync(IdentityRole role);
    }
}
