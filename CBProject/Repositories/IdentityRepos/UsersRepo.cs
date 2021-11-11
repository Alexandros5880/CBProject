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
            user.IsInactive = true;
            this.Update(user);
            //this._manager.UserManager.Delete(user);
        }

        public async Task<int> DeleteAsync(string id)
        {
            if (id.Length == 0)
                throw new Exception("In Users repo delete method id is empty.");
            var user = this.Get(id);
            user.IsInactive = true;
            return await this.UpdateAsync(user);
            //return await this._manager.UserManager.DeleteAsync(user);
        }

        public void FinalDelete(string id)
        {
            var user = this.Get(id);
            var logins = user.Logins;
            IdentityResult result;
            var rolesForUser = this._manager.UserManager.GetRoles(user.Id);
            using (var transaction = this._manager.Context.Database.BeginTransaction())
            {
                foreach (var login in logins.ToList())
                {
                    this._manager.UserManager.RemoveLogin(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                }
                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser.ToList())
                    {
                        this._manager.UserManager.RemoveFromRole(user.Id, item);
                    }
                }
                result = this._manager.UserManager.Delete(user);
                transaction.Commit();
            }
        }

        public async Task<IdentityResult> FinalDeleteAsync(string id)
        {
            var user = await this.GetAsync(id);
            var logins = user.Logins;
            IdentityResult result;
            var rolesForUser = await this._manager.UserManager.GetRolesAsync(user.Id);
            using (var transaction = this._manager.Context.Database.BeginTransaction())
            {
                foreach (var login in logins.ToList())
                {
                    await this._manager.UserManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                }
                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser.ToList())
                    {
                        await this._manager.UserManager.RemoveFromRoleAsync(user.Id, item);
                    }
                }
                result = await this._manager.UserManager.DeleteAsync(user);
                transaction.Commit();
            }
            return result;
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

            var user = this.Get(obj.Id);
            user.BirthDate = obj.BirthDate;
            user.FirstName = obj.FirstName;
            user.LastName = obj.LastName;
            user.Email = obj.Email;
            user.Password = obj.Password;
            user.PhoneNumber = obj.PhoneNumber;
            user.Country = obj.Country;
            user.State = obj.State;
            user.City = obj.City;
            user.PostalCode = obj.PostalCode;
            user.Street = obj.Street;
            user.StreetNumber = obj.StreetNumber;
            user.NewsletterAcception = obj.NewsletterAcception;
            user.IsInactive = obj.IsInactive;
            user.CreditCardNum = obj.CreditCardNum;
            user.SubscriptionId = obj.SubscriptionId;
            user.ContentAccess = obj.ContentAccess;
            user.ContentCategoryId = obj.ContentCategoryId;
            user.ContentId = obj.ContentId;

            this._manager.UserManager.Update(obj);
            this._manager.Context.SaveChanges();
        }

        public async Task<int> UpdateAsync(ApplicationUser obj)
        {
            if (obj == null)
                throw new NullReferenceException("In Users repository Update method parametrer is null.");

            var user = await this.GetAsync(obj.Id);
            user.BirthDate = obj.BirthDate;
            user.FirstName = obj.FirstName;
            user.LastName = obj.LastName;
            user.Email = obj.Email;
            user.Password = obj.Password;
            user.PhoneNumber = obj.PhoneNumber;
            user.Country = obj.Country;
            user.State = obj.State;
            user.City = obj.City;
            user.PostalCode = obj.PostalCode;
            user.Street = obj.Street;
            user.StreetNumber = obj.StreetNumber;
            user.NewsletterAcception = obj.NewsletterAcception;
            user.IsInactive = obj.IsInactive;
            user.CreditCardNum = obj.CreditCardNum;
            user.SubscriptionId = obj.SubscriptionId;
            user.ContentAccess = obj.ContentAccess;
            user.ContentCategoryId = obj.ContentCategoryId;
            user.ContentId = obj.ContentId;
            await this._manager.UserManager.UpdateAsync(obj);
            return await this._manager.Context.SaveChangesAsync();
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