using CBProject.Areas.Forum.Models.EntityModels;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Areas.Forum.Repositories
{
    public class ForumQuestionsRepository : IRepository<ForumQuestion>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public ForumQuestionsRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(ForumQuestion obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ForumQuestions.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ForumQuestions
                                    .FirstOrDefault(f => f.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ForumQuestions.Remove(obj);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ForumQuestions
                                    .FirstOrDefaultAsync(f => f.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ForumQuestions.Remove(obj);
        }
        public ForumQuestion Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ForumQuestions
                                    .Include(f => f.User)
                                    .Include(f => f.Answers)
                                    .FirstOrDefault(f => f.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ICollection<ForumQuestion> GetAll()
        {
            return this._context.ForumQuestions
                                .Include(f => f.User)
                                .Include(f => f.Answers)
                                .ToList();
        }
        public async Task<ICollection<ForumQuestion>> GetAllAsync()
        {
            return await this._context.ForumQuestions
                                .Include(f => f.User)
                                .Include(f => f.Answers)
                                .ToListAsync();
        }
        public ICollection<ForumQuestion> GetAllEmpty()
        {
            return this._context.ForumQuestions
                                .ToList();
        }
        public async Task<ICollection<ForumQuestion>> GetAllEmptyAsync()
        {
            return await this._context.ForumQuestions
                                        .ToListAsync();
        }
        public IQueryable<ForumQuestion> GetAllQueryable()
        {
            return this._context.ForumQuestions;
        }
        public async Task<ForumQuestion> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ForumQuestions
                                    .Include(f => f.User)
                                    .Include(f => f.Answers)
                                    .FirstOrDefaultAsync(f => f.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ForumQuestion GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ForumQuestions
                                    .FirstOrDefault(f => f.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public async Task<ForumQuestion> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ForumQuestions
                                    .FirstOrDefaultAsync(f => f.ID == id);
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
        public void Update(ForumQuestion obj)
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