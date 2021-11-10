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
        private RoleManager<IdentityRole> _roleManager;

        public RolesRepo(IDataManagers manager)
        {
            this._roleManager = ((DataManagers)manager).RoleManager;
        }

        public IdentityRole Get(string id)
        {
            return this._roleManager.FindById(id);
        }

        public IdentityRole GetByName(string name)
        {
            return this._roleManager.FindByName(name);
        }
        public ICollection<IdentityRole> GetAll()
        {
            return this._roleManager.Roles.ToList();
        }

        public async Task<IdentityRole> GetAsync(string id)
        {
            return await this._roleManager.FindByIdAsync(id);
        }

        public async Task<IdentityRole> GetByNameAsync(string name)
        {
            return await this._roleManager.FindByNameAsync(name);
        }

        public async Task<ICollection<IdentityRole>> GetAllAsync()
        {
            return await this._roleManager.Roles.ToListAsync();
        }

        public void Add(string name)
        {
            if(!this._roleManager.RoleExists(name))
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = name
                };
                this._roleManager.Create(role);
            }
        }

        public void Add(IdentityRole role)
        {
            if (!this._roleManager.RoleExists(role.Name))
            {
                this._roleManager.Create(role);
            }
        }

        public async Task<IdentityResult> AddAsync(string name)
        {
            if (!this._roleManager.RoleExists(name))
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = name
                };
                return await this._roleManager.CreateAsync(role);
            }
            return null;
        }

        public async Task<IdentityResult> AddAsync(IdentityRole role)
        {
            if (!this._roleManager.RoleExists(role.Name))
            {
                return await this._roleManager.CreateAsync(role);
            }
            return null;
        }

        public void Delete(string name)
        {
            if (this._roleManager.RoleExists(name))
            {
                this._roleManager.Delete(this.GetByName(name));
            }
        }

        public async Task<IdentityResult> DeleteAsync(string name)
        {
            if (this._roleManager.RoleExists(name))
            {
                return await this._roleManager.DeleteAsync(this.GetByName(name));
            }
            return null;
        }

        public void Update(string oldName, string newName)
        {
            IdentityRole role = this.GetByName(oldName);
            role.Name = newName;
            this._roleManager.Update(role);
        }

        public void Update(IdentityRole role)
        {
            this._roleManager.Update(role);
        }

        public async Task<IdentityResult> UpdateAsync(string oldName, string newName)
        {
            IdentityRole role = await this.GetByNameAsync(oldName);
            role.Name = newName;
            return await this._roleManager.UpdateAsync(role);
        }

        public async Task<IdentityResult> UpdateAsync(IdentityRole role)
        {
            return await this._roleManager.UpdateAsync(role);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._roleManager.Dispose();
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