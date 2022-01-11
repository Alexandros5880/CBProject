using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Repositories.IdentityRepos.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Repositories.IdentityRepos
{
    public class RolesRepo : IRolesRepo,  IDisposable
    {
        private bool disposedValue;
        private UnitOfWork _manager;
        public RolesRepo(IUnitOfWork manager)
        {
            this._manager = ((UnitOfWork)manager);
        }
        public ApplicationRole Get(string id)
        {
            return this._manager.RoleManager.FindById(id);
        }
        public ApplicationRole GetByName(string name)
        {
            return this._manager.RoleManager.FindByName(name);
        }
        public ICollection<ApplicationRole> GetAll()
        {
            return this._manager.RoleManager.Roles.ToList();
        }
        public ICollection<ApplicationRole> GetAllByNames(ICollection<string> names)
        {
            return this._manager.RoleManager.Roles.Where(r => names.Contains(r.Name)).ToList();
        }
        public async Task<ApplicationRole> GetAsync(string id)
        {
            return await this._manager.RoleManager.FindByIdAsync(id);
        }
        public async Task<ApplicationRole> GetByNameAsync(string name)
        {
            return await this._manager.RoleManager.FindByNameAsync(name);
        }
        public async Task<ICollection<ApplicationRole>> GetAllAsync()
        {
            return await this._manager.RoleManager.Roles.ToListAsync();
        }
        public async Task<ICollection<ApplicationRole>> GetAllByNamesAsync(ICollection<string> names)
        {
            return await this._manager.RoleManager.Roles.Where(r => names.Contains(r.Name)).ToListAsync();
        }
        public void Add(string name, RoleLevel level)
        {
            if(!this._manager.RoleManager.RoleExists(name))
            {
                ApplicationRole role = new ApplicationRole()
                {
                    Name = name,
                    Level = level
                };
                this._manager.RoleManager.Create(role);
            }
        }
        public void Add(ApplicationRole role)
        {
            if (!this._manager.RoleManager.RoleExists(role.Name))
            {
                this._manager.RoleManager.Create(role);
            }
        }
        public async Task<IdentityResult> AddAsync(string name, RoleLevel level)
        {
            if (!this._manager.RoleManager.RoleExists(name))
            {
                ApplicationRole role = new ApplicationRole()
                {
                    Name = name,
                    Level = level
                };
                return await this._manager.RoleManager.CreateAsync(role);
            }
            return null;
        }
        public async Task<IdentityResult> AddAsync(ApplicationRole role)
        {
            if (!this._manager.RoleManager.RoleExists(role.Name))
            {
                return await this._manager.RoleManager.CreateAsync(role);
            }
            return null;
        }
        public void Delete(string name)
        {
            if (!name.Equals("Admin") &&
                !name.Equals("Student") &&
                !name.Equals("Teacher") &&
                !name.Equals("Guest") &&
                !name.Equals("Manager"))
            {
                if (this._manager.RoleManager.RoleExists(name))
                {
                    this._manager.RoleManager.Delete(this.GetByName(name));
                }
            }
        }
        public async Task<IdentityResult> DeleteAsync(string name)
        {
            if (this._manager.RoleManager.RoleExists(name))
            {
                
            }
            if (!name.Equals("Admin") &&
                !name.Equals("Student") &&
                !name.Equals("Teacher") &&
                !name.Equals("Guest") &&
                !name.Equals("Manager"))
            {
                if (this._manager.RoleManager.RoleExists(name))
                {
                    return await this._manager.RoleManager.DeleteAsync(this.GetByName(name));
                }
            } 
            return null;
        }
        public void Update(string oldName, string newName)
        {
            if (!oldName.Equals("Admin") &&
                !oldName.Equals("Student") &&
                !oldName.Equals("Teacher") &&
                !oldName.Equals("Guest") &&
                !oldName.Equals("Manager"))
            {
                ApplicationRole role = this.GetByName(oldName);
                role.Name = newName;
                this._manager.RoleManager.Update(role);
                this._manager.Context.SaveChanges();
            }
        }
        public void Update(ApplicationRole role)
        {
            if (!role.Name.Equals("Admin") &&
                !role.Name.Equals("Student") &&
                !role.Name.Equals("Teacher") &&
                !role.Name.Equals("Guest") &&
                !role.Name.Equals("Manager"))
            {
                this._manager.RoleManager.Update(role);
            }
        }
        public async Task<IdentityResult> UpdateAsync(string oldName, string newName)
        {
            ApplicationRole role = await this.GetByNameAsync(oldName);
            role.Name = newName;
            //await this._manager.RoleManager.UpdateAsync(role);
            //return await this._manager.Context.SaveChangesAsync();
            return await this._manager.RoleManager.UpdateAsync(role);
        }
        public async Task<IdentityResult> UpdateAsync(ApplicationRole role)
        {
            //await this._manager.RoleManager.UpdateAsync(role);
            //return await this._manager.Context.SaveChangesAsync();
            return await this._manager.RoleManager.UpdateAsync(role);
        }
        public IQueryable<ApplicationRole>GetAllQuerable()
        {
            return this._manager.RoleManager.Roles;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._manager.RoleManager.Dispose();
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