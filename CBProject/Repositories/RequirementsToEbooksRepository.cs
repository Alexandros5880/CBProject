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
    public class RequirementsToEbooksRepository : IRepository<RequirementToEbook>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public RequirementsToEbooksRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(RequirementToEbook obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.RequirementsToEbooks.Add(obj);
            this._context.SaveChanges();
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.RequirementsToEbooks
                            .FirstOrDefault(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.RequirementsToEbooks.Remove(obj);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.RequirementsToEbooks
                                    .FirstOrDefaultAsync(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.RequirementsToEbooks.Remove(obj);
        }
        public RequirementToEbook Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.RequirementsToEbooks
                            .Include(r => r.Ebook)
                            .Include(r => r.Requirement)
                            .FirstOrDefault(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ICollection<RequirementToEbook> GetAll()
        {
            return this._context.RequirementsToEbooks
                                .Include(r => r.Ebook)
                                .Include(r => r.Requirement)
                                .ToList();
        }
        public async Task<ICollection<RequirementToEbook>> GetAllAsync()
        {
            return await this._context.RequirementsToEbooks
                                        .Include(r => r.Ebook)
                                        .Include(r => r.Requirement)
                                        .ToListAsync();
        }
        public ICollection<RequirementToEbook> GetAllEmpty()
        {
            return this._context.RequirementsToEbooks.ToList();
        }
        public async Task<ICollection<RequirementToEbook>> GetAllEmptyAsync()
        {
            return await this._context.RequirementsToEbooks.ToListAsync();
        }
        public IQueryable<RequirementToEbook> GetAllQueryable()
        {
            return this._context.RequirementsToEbooks;
        }
        public async Task<RequirementToEbook> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.RequirementsToEbooks
                                .Include(r => r.Ebook)
                                .Include(r => r.Requirement)
                                .FirstOrDefaultAsync(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public RequirementToEbook GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.RequirementsToEbooks
                            .FirstOrDefault(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public async Task<RequirementToEbook> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.RequirementsToEbooks
                                    .FirstOrDefaultAsync(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public void Save()
        {
            this._context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
        public void Update(RequirementToEbook obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.Entry(obj).State = EntityState.Modified;
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