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
        private UnitOfWork _manager;
        public UsersRepo(IUnitOfWork manager)
        {
            this._manager = (UnitOfWork) manager;
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
            //this._manager.UserManager.UserValidator = new UserValidator<ApplicationUser>(this._manager.UserManager)
            //{
            //    AllowOnlyAlphanumericUserNames = false,
            //    RequireUniqueEmail = true
            //};

            var result = await this._manager.UserManager.CreateAsync(obj, obj.Password);
            if ( result.Succeeded )
            {
                return result;
                //await SignInManager.SignInAsync(obj, isPersistent: false, rememberBrowser: false);
            }
            return null;
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
        public void DeleteReal(string id)
        {
            if (id.Length == 0)
                throw new Exception("In Users repo delete method id is empty.");
            var user = this.Get(id);
            this.RemoveRoles(user);
            this._manager.UserManager.Delete(user);
        }
        public async Task<IdentityResult> DeleteRealAsync(string id)
        {
            if (id.Length == 0)
                throw new Exception("In Users repo delete method id is empty.");
            var user = this.Get(id);
            this.RemoveRoles(user);
            return await this._manager.UserManager.DeleteAsync(user);
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
            return this._manager.UserManager
                .FindById(id);
        }
        public async Task<ApplicationUser> GetAsync(string id)
        {
            if (id.Length == 0)
                throw new Exception("In Users repo Get method id is empty.");
            return await this._manager.UserManager.FindByIdAsync(id);
        }
        public ApplicationUser GetByEmail(string email)
        {
            if (email.Length == 0)
                throw new Exception("In Users repo Get method id is empty.");
            return this._manager.UserManager.FindByEmail(email);
        }
        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            if (email.Length == 0)
                throw new Exception("In Users repo Get method id is empty.");
            return await this._manager.UserManager.FindByEmailAsync(email);
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
        public List<IdentityRole> GetRolesForUser(ApplicationUser user)
        {
            var userRoles = _manager.UserManager.GetRoles(user.Id);
            var roles = _manager.RoleManager.Roles.Where(r => !userRoles.Contains(r.Name)).ToList();
            return roles;
        }
        public async Task<List<IdentityRole>> GetRolesForUserAsync(ApplicationUser user)
        {
            var userRoles = await _manager.UserManager.GetRolesAsync(user.Id);
            var roles = await _manager.RoleManager.Roles.Where(r => !userRoles.Contains(r.Name)).ToListAsync();
            return roles;
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
            _manager.UserManager.RemoveFromRole(user.Id, role.Name);
        }
        public void RemoveRoles(ApplicationUser user)
        {
            var rolesId = user.Roles.Select(r => r.RoleId).ToList();
            var roleRepo = new RolesRepo(_manager);
            var rolesNames = roleRepo.GetAll()
                .Where(r => rolesId.Contains(r.Id))
                .Select(r => r.Name)
                .ToArray();
            _manager.UserManager.RemoveFromRoles(user.Id, rolesNames);
        }
        public void AddRole(ApplicationUser user, IdentityRole role)
        {
            if (user == null)
                throw new Exception("User == Null.");
            if (role == null)
                throw new Exception("Role == Null.");
            if (!_manager.UserManager.IsInRole(user.Id, role.Name))
                _manager.UserManager.AddToRole(user.Id, role.Name);
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
            user.UserName = obj.Email;
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
            user.ImagePath = obj.ImagePath;
            user.CVPath = obj.CVPath;
            this._manager.UserManager.Update(user);
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
            user.UserName = obj.Email;
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
            user.ImagePath = obj.ImagePath;
            user.CVPath = obj.CVPath;
            await this._manager.UserManager.UpdateAsync(user);
            return await this._manager.Context.SaveChangesAsync();
        }
        public void ChangePassword(string userId, string newPassword)
        {
            var user = _manager.UserManager.FindById(userId);
            user.Password = newPassword;
            user.PasswordHash = _manager.UserManager.PasswordHasher.HashPassword(newPassword);
        }
        public async Task<Task> ChangePasswordAsync(string userId, string newPassword)
        {
            var user = await _manager.UserManager.FindByIdAsync(userId);
            user.Password = newPassword;
            user.PasswordHash = _manager.UserManager.PasswordHasher.HashPassword(newPassword);
            return Task.CompletedTask;
        }
        public IQueryable<ApplicationUser> GetAllEnumerable()
        {
            return this._manager.UserManager.Users;
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