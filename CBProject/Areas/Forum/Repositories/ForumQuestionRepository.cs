using CBProject.Areas.Forum.Models.EntityModels;
using CBProject.Areas.Forum.Repositories.Interfaces;
using CBProject.HelperClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Areas.Forum.Repositories
{
    public class ForumQuestionRepository : IRepository<ForumQuestion>, IDisposable
    {
        private bool disposedValue;

        public ForumQuestionRepository(IUnitOfWork unitOfWork)
        {

        }

        public void Add(ForumQuestion obj)
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

        public ForumQuestion Get(int? id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<ForumQuestion> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<ForumQuestion>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<ForumQuestion> GetAllEmpty()
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<ForumQuestion>> GetAllEmptyAsync()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ForumQuestion> GetAllQueryable()
        {
            throw new System.NotImplementedException();
        }

        public Task<ForumQuestion> GetAsync(int? id)
        {
            throw new System.NotImplementedException();
        }

        public ForumQuestion GetEmpty(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ForumQuestion> GetEmptyAsync(int? id)
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

        public void Update(ForumQuestion obj)
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