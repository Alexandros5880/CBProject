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
    public class RequirementsToVideosRepository : IRepository<RequirementToVideo>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public RequirementsToVideosRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(RequirementToVideo obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.RequirementsToVideos.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.RequirementsToVideos
                                    .FirstOrDefault(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.RequirementsToVideos.Remove(obj);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.RequirementsToVideos
                                            .FirstOrDefaultAsync(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.RequirementsToVideos.Remove(obj);
        }
        public RequirementToVideo Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.RequirementsToVideos
                                    .FirstOrDefault(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ICollection<RequirementToVideo> GetAll()
        {
            return this._context.RequirementsToVideos
                                .Include(r => r.Video)
                                .Include(r => r.Requirement)
                                .ToList();
        }
        public async Task<ICollection<RequirementToVideo>> GetAllAsync()
        {
            return await this._context.RequirementsToVideos
                                        .Include(r => r.Video)
                                        .Include(r => r.Requirement)
                                        .ToListAsync();
        }
        public ICollection<RequirementToVideo> GetAllEmpty()
        {
            return this._context.RequirementsToVideos
                                .ToList();
        }
        public async Task<ICollection<RequirementToVideo>> GetAllEmptyAsync()
        {
            return await this._context.RequirementsToVideos
                                        .ToListAsync();
        }
        public IQueryable<RequirementToVideo> GetAllQueryable()
        {
            return this._context.RequirementsToVideos;
        }
        public async Task<RequirementToVideo> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.RequirementsToVideos
                                            .Include(r => r.Video)
                                            .Include(r => r.Requirement)
                                            .FirstOrDefaultAsync(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public RequirementToVideo GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.RequirementsToVideos
                                    .FirstOrDefault(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public async Task<RequirementToVideo> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.RequirementsToVideos
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
        public void Update(RequirementToVideo obj)
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