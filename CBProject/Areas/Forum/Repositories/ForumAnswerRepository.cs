﻿using CBProject.Areas.Forum.Models.EntityModels;
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
    public class ForumAnswerRepository : IRepository<ForumAnswer>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public ForumAnswerRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(ForumAnswer obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ForumAnswers.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ForumAnswers.FirstOrDefault(a => a.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ForumAnswers.Remove(obj);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ForumAnswers.FirstOrDefaultAsync(a => a.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ForumAnswers.Remove(obj);
        }
        public ForumAnswer Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ForumAnswers
                        .Include(a => a.User)
                        .Include(a => a.Question)
                        .FirstOrDefault(a => a.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ICollection<ForumAnswer> GetAll()
        {
            return this._context.ForumAnswers
                        .Include(a => a.User)
                        .Include(a => a.Question)
                        .ToList();
        }
        public async Task<ICollection<ForumAnswer>> GetAllAsync()
        {
            return await this._context.ForumAnswers
                        .Include(a => a.User)
                        .Include(a => a.Question)
                        .ToListAsync();
        }
        public ICollection<ForumAnswer> GetAllEmpty()
        {
            return this._context.ForumAnswers
                                .ToList();
        }
        public async Task<ICollection<ForumAnswer>> GetAllEmptyAsync()
        {
            return await this._context.ForumAnswers
                                        .ToListAsync();
        }
        public IQueryable<ForumAnswer> GetAllQueryable()
        {
            return this._context.ForumAnswers;
        }
        public async Task<ForumAnswer> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ForumAnswers
                        .Include(a => a.User)
                        .Include(a => a.Question)
                        .FirstOrDefaultAsync(a => a.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ForumAnswer GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ForumAnswers
                        .FirstOrDefault(a => a.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public async Task<ForumAnswer> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj =  await this._context.ForumAnswers
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
        public void Update(ForumAnswer obj)
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