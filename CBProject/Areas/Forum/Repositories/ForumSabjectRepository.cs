using CBProject.Areas.Forum.Models.EntityModels;
using CBProject.Areas.Forum.Repositories.Interfaces;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Areas.Forum.Repositories
{
    public class ForumSabjectRepository :  IRepository<ForumSabject>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public ForumSabjectRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(ForumSabject obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ForumSubjects.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ForumSubjects
                        .FirstOrDefault(s => s.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ForumSubjects.Remove(obj);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ForumSubjects
                        .FirstOrDefaultAsync(s => s.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ForumSubjects.Remove(obj);
        }
        public ForumSabject Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ForumSubjects
                            .Include(s => s.Questions)
                            .FirstOrDefault(a => a.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ICollection<ForumSabject> GetAll()
        {
            return this._context.ForumSubjects
                            .Include(s => s.Questions)
                            .ToList();
        }
        public async Task<ICollection<ForumSabject>> GetAllAsync()
        {
            return await this._context.ForumSubjects
                            .Include(s => s.Questions)
                            .ToListAsync();
        }
        public ICollection<ForumSabject> GetAllEmpty()
        {
            return this._context.ForumSubjects
                                .ToList();
        }
        public async Task<ICollection<ForumSabject>> GetAllEmptyAsync()
        {
            return await this._context.ForumSubjects
                                        .ToListAsync();
        }
        public IQueryable<ForumSabject> GetAllQueryable()
        {
            return this._context.ForumSubjects;
        }
        public async Task<ForumSabject> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ForumSubjects
                            .Include(s => s.Questions)
                            .FirstOrDefaultAsync(a => a.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ForumSabject GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ForumSubjects
                            .FirstOrDefault(a => a.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public async Task<ForumSabject> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ForumSubjects
                            .Include(s => s.Questions)
                            .FirstOrDefaultAsync(a => a.ID == id);
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
        public void Update(ForumSabject obj)
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