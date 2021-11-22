using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
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
    public class RolesRepo : IRolesRepo,  IDisposable
    {
        private bool disposedValue;
        private UnitOfWork _manager;
        public RolesRepo(IUnitOfWork manager)
        {
            this._manager = ((UnitOfWork)manager);
        }
        public IdentityRole Get(string id)
        {
            return this._manager.RoleManager.FindById(id);
        }
        public IdentityRole GetByName(string name)
        {
            return this._manager.RoleManager.FindByName(name);
        }
        public ICollection<IdentityRole> GetAll()
        {
            return this._manager.RoleManager.Roles.ToList();
        }
        public ICollection<IdentityRole> GetAllByNames(ICollection<string> names)
        {
            return this._manager.RoleManager.Roles.Where(r => names.Contains(r.Name)).ToList();
        }
        public async Task<IdentityRole> GetAsync(string id)
        {
            return await this._manager.RoleManager.FindByIdAsync(id);
        }
        public async Task<IdentityRole> GetByNameAsync(string name)
        {
            return await this._manager.RoleManager.FindByNameAsync(name);
        }
        public async Task<ICollection<IdentityRole>> GetAllAsync()
        {
            return await this._manager.RoleManager.Roles.ToListAsync();
        }
        public async Task<ICollection<IdentityRole>> GetAllByNamesAsync(ICollection<string> names)
        {
            return await this._manager.RoleManager.Roles.Where(r => names.Contains(r.Name)).ToListAsync();
        }
        public void Add(string name)
        {
            if(!this._manager.RoleManager.RoleExists(name))
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = name
                };
                this._manager.RoleManager.Create(role);
            }
        }
        public void Add(IdentityRole role)
        {
            if (!this._manager.RoleManager.RoleExists(role.Name))
            {
                this._manager.RoleManager.Create(role);
            }
        }
        public async Task<IdentityResult> AddAsync(string name)
        {
            if (!this._manager.RoleManager.RoleExists(name))
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = name
                };
                return await this._manager.RoleManager.CreateAsync(role);
            }
            return null;
        }
        public async Task<IdentityResult> AddAsync(IdentityRole role)
        {
            if (!this._manager.RoleManager.RoleExists(role.Name))
            {
                return await this._manager.RoleManager.CreateAsync(role);
            }
            return null;
        }
        public void Delete(string name)
        {
            if (this._manager.RoleManager.RoleExists(name))
            {
                this._manager.RoleManager.Delete(this.GetByName(name));
            }
        }
        public async Task<IdentityResult> DeleteAsync(string name)
        {
            if (this._manager.RoleManager.RoleExists(name))
            {
                return await this._manager.RoleManager.DeleteAsync(this.GetByName(name));
            }
            return null;
        }
        public void Update(string oldName, string newName)
        {
            IdentityRole role = this.GetByName(oldName);
            role.Name = newName;
            this._manager.RoleManager.Update(role);
            this._manager.Context.SaveChanges();
        }
        public void Update(IdentityRole role)
        {
            //this._manager.RoleManager.Update(role);
            //this._manager.Context.SaveChanges();
            this._manager.RoleManager.Update(role);
        }
        public async Task<IdentityResult> UpdateAsync(string oldName, string newName)
        {
            IdentityRole role = await this.GetByNameAsync(oldName);
            role.Name = newName;
            //await this._manager.RoleManager.UpdateAsync(role);
            //return await this._manager.Context.SaveChangesAsync();
            return await this._manager.RoleManager.UpdateAsync(role);
        }
        public async Task<IdentityResult> UpdateAsync(IdentityRole role)
        {
            //await this._manager.RoleManager.UpdateAsync(role);
            //return await this._manager.Context.SaveChangesAsync();
            return await this._manager.RoleManager.UpdateAsync(role);
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