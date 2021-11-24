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
    public class EbooksRepository : IRepository<Ebook>
    {
        private readonly ApplicationDbContext _context;
        public EbooksRepository(IApplicationDbContext context)
        {
            _context = (ApplicationDbContext)context;
        }
        public void Add(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            _context.Ebooks.Add(ebook);
        }
        public void Update(Ebook ebook)
        {
           if(ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            _context.Entry(ebook).State = EntityState.Modified;
        }
        public Ebook Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return _context.Ebooks.FirstOrDefault(e=>e.ID == id);
        }
        public ICollection<Ebook> GetAll()
        {
            return _context.Ebooks.ToList();
        }
        public void Delete(int? id)
        {
           
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ebook = Get(id);
            if(ebook == null)
                throw new ArgumentNullException(nameof(id));
            _context.Ebooks.Remove(ebook);
        }
        public async Task<ICollection<Ebook>> GetAllAsync()
        {
            return await _context.Ebooks.ToListAsync();
        }
        public ICollection<Ebook> GetAllEmpty()
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<Ebook>> GetAllEmptyAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<Ebook> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
           var ebook = await _context.Ebooks.FindAsync(id);
            if(ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return ebook;


        }
        public Ebook GetEmpty(int? id)
        {
            throw new NotImplementedException();
        }
        public Task<Ebook> GetEmptyAsync(int? id)
        {
            throw new NotImplementedException();
        }
        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}