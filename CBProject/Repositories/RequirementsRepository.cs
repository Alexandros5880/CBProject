using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Repositories
{
    public class RequirementsRepository : IRepository<Requirement>, IDisposable
    {
        private bool disposedValue;
        private ApplicationDbContext _context { get; set; }
        public RequirementsRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(Requirement obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.Requirements.Add(obj);
        }
        public void Update(Requirement obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var requirement = this._context.Requirements.FirstOrDefault(r => r.ID == id);
            if (requirement == null)
                throw new ArgumentNullException(nameof(id));
            this._context.Requirements.Remove(requirement);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var requirement = await this._context.Requirements
                                            .FirstOrDefaultAsync(r => r.ID == id);
            this._context.Requirements.Remove(requirement);
        }
        public Requirement Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.Requirements.FirstOrDefault(r => r.ID == id);
        }
        public async Task<Requirement> GetAsync(int? id)
        {
            return await this._context.Requirements.FirstOrDefaultAsync(r => r.ID == id);
        }
        public Requirement GetEmpty(int? id)
        {
            return this._context.Requirements.FirstOrDefault(r => r.ID == id);
        }
        public async Task<Requirement> GetEmptyAsync(int? id)
        {
            return await this._context.Requirements.FirstOrDefaultAsync(r => r.ID == id);
        }
        public ICollection<Requirement> GetAll()
        {
            return this._context.Requirements.ToList();
        }
        public async Task<ICollection<Requirement>> GetAllAsync()
        {
            return await this._context.Requirements.ToListAsync();
        }
        public ICollection<Requirement> GetAllEmpty()
        {
            return this._context.Requirements.ToList();
        }
        public async Task<ICollection<Requirement>> GetAllEmptyAsync()
        {
            return await this._context.Requirements.ToListAsync();
        }
        public IQueryable<Requirement> GetAllQueryable()
        {
            return this._context.Requirements;
        }
        public void Save()
        {
            this._context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._context.Dispose();
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