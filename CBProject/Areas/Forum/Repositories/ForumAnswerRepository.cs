using CBProject.Areas.Forum.Models.EntityModels;
using CBProject.Areas.Forum.Repositories.Interfaces;
using CBProject.HelperClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Areas.Forum.Repositories
{
    public class ForumAnswerRepository : IRepository<ForumAnswer>, IDisposable
    {
        private bool disposedValue;

        public ForumAnswerRepository(IUnitOfWork unitOfWork)
        {

        }

        public void Add(ForumAnswer obj)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int? id)
        {
            throw new System.NotImplementedException();
        }

        public ForumAnswer Get(int? id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<ForumAnswer> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<ForumAnswer>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<ForumAnswer> GetAllEmpty()
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<ForumAnswer>> GetAllEmptyAsync()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ForumAnswer> GetAllQueryable()
        {
            throw new System.NotImplementedException();
        }

        public Task<ForumAnswer> GetAsync(int? id)
        {
            throw new System.NotImplementedException();
        }

        public ForumAnswer GetEmpty(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ForumAnswer> GetEmptyAsync(int? id)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(ForumAnswer obj)
        {
            throw new System.NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

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