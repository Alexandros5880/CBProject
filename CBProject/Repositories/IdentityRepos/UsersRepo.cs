using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Repositories.IdentityRepos.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Repositories.IdentityRepos
{
    public class UsersRepo : IUsersRepo, IDisposable
    {
        private bool disposedValue;
        private DataManagers _manager;

        public UsersRepo(IDataManagers manager)
        {
            this._manager = (DataManagers) manager;
        }

        public void Add(ApplicationUser obj)
        {
            if (obj == null)
                throw new NullReferenceException("In user repo add method user object is null.");
            this._manager.UserManager.Create(obj, obj.Password);
        }

        public async Task<IdentityResult> AddAsync(ApplicationUser obj)
        {
            if (obj == null)
                throw new NullReferenceException("In user repo add method user object is null.");
            return await this._manager.UserManager.CreateAsync(obj, obj.Password);
        }

        public void Delete(string id)
        {
            if (id.Length == 0)
                throw new Exception("In Users repo delete method id is empty.");
            var user = this.Get(id);
            this._manager.UserManager.Delete(user);
        }

        public async Task<IdentityResult> DeleteAsync(string id)
        {
            if (id.Length == 0)
                throw new Exception("In Users repo delete method id is empty.");
            var user = this.Get(id);
            return await this._manager.UserManager.DeleteAsync(user);
        }

        public ApplicationUser Get(string id)
        {
            if (id.Length == 0)
                throw new Exception("In Users repo Get method id is empty.");
            return this._manager.UserManager.FindById(id);
        }

        public async Task<ApplicationUser> GetAsync(string id)
        {
            if (id.Length == 0)
                throw new Exception("In Users repo Get method id is empty.");
            return await this._manager.UserManager.FindByIdAsync(id);
        }

        public ICollection<string> GetRoles(ApplicationUser user)
        {
            return (ICollection<string>)this._manager.UserManager.GetRoles(user.Id);
        }

        public async Task<ICollection<string>> GetRolesAsync(ApplicationUser user)
        {
            return await this._manager.UserManager.GetRolesAsync(user.Id);
        }

        public ICollection<ApplicationUser> GetAll()
        {
            return this._manager.UserManager.Users.ToList();
        }

        public ICollection<ApplicationUser> GetAll(List<string> usernames)
        {
            return this._manager.UserManager.Users
                .Where(u => usernames.Contains(u.UserName))
                .ToList();
        }

        public async Task<ICollection<ApplicationUser>> GetAllAsync()
        {
            return await this._manager.UserManager.Users.ToListAsync<ApplicationUser>();
        }

        public async Task<ICollection<ApplicationUser>> GetAllAsync(List<string> usernames)
        {
            return await this._manager.UserManager.Users
                .Where(u => usernames.Contains(u.UserName))
                .ToListAsync();
        }

        public List<string> GetRolesForUser(ApplicationUser user)
        {
            return this._manager.UserManager.GetRoles(user.Id).ToList();
        }

        public async Task<List<string>> GetRolesForUserAsync(ApplicationUser user)
        {
            return (List<string>) await this._manager.UserManager.GetRolesAsync(user.Id);
        }

        public ICollection<ApplicationUser> GetUsersFromRole(string name)
        {
            var role = this._manager.RoleManager.FindByName(name);
            var usersIds = role.Users.Select(u => u.UserId);
            return this._manager.UserManager.Users.Where(u => usersIds.Contains(u.Id)).ToList();
        }

        public async Task<ICollection<ApplicationUser>> GetUsersFromRoleAsync(string name)
        {
            var role = await this._manager.RoleManager.FindByNameAsync(name);
            var usersIds = role.Users.Select(u => u.UserId).ToList();
            return await this._manager.UserManager.Users.Where(u => usersIds.Contains(u.Id)).ToListAsync();
        }

        public void RemoveRole(ApplicationUser user, IdentityRole role)
        {
            IdentityUserRole userRole = user.Roles.FirstOrDefault(ur => ur.RoleId.Equals(role.Id));
            user.Roles.Remove(userRole);
        }

        public void AddRole(ApplicationUser user, IdentityRole role)
        {
            IdentityUserRole userRole = new IdentityUserRole()
            {
                UserId = user.Id,
                RoleId = role.Id
            };
            user.Roles.Add(userRole);
        }

        public void Update(ApplicationUser obj)
        {
            if (obj == null)
                throw new NullReferenceException("In Users repository Update method parametrer is null.");
            this._manager.UserManager.Update(obj);
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationUser obj)
        {
            if (obj == null)
                throw new NullReferenceException("In Users repository Update method parametrer is null.");
            return await this._manager.UserManager.UpdateAsync(obj);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._manager.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}