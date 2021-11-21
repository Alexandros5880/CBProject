using CBProject.Models;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CBProject.Repositories
{
    public class TagsRepository : IRepository<Tag>
    {
        private readonly ApplicationDbContext _context;

        public TagsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));

            _context.Tags.Add(tag);
        }

        

        public void Delete(int id)
        {
            var tag = Get(id);

            if (tag == null)
                throw new Exception("Tag Not Found");

            _context.Tags.Remove(tag);
        }
        

        public Tag Get(int id)
        {
            return _context.Tags.Find(id);
        }

        public ICollection<Tag> GetAll()
        {
            return _context.Tags.ToList();
        }       

        public ICollection<Tag> GetAllEmpty()
        {
            throw new NotImplementedException();
        }      

        public Tag GetEmpty(int id)
        {
            throw new NotImplementedException();
        }        

        public void Save()
        {
            _context.SaveChanges();
        }       

        public void Update(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));

            _context.Entry(tag).State = EntityState.Modified;
        }

        //-----------------------ASYNC---------------------------------------

        public Task<int> UpdateAsync(Tag obj)
        {
            throw new NotImplementedException();
        }


        public Task<int> AddAsync(Tag obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Tag> GetEmptyAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Tag>> GetAllEmptyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Tag>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}