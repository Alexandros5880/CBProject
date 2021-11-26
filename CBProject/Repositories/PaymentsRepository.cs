using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModel;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace CBProject.Repositories.IdentityRepos
{
    public class PaymentsRepository : IRepository<Payment>, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposedValue;

        public PaymentsRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(Payment obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.Payments.Add(obj);
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var payment = this._context.Payments.FirstOrDefault(p => p.ID == id);
            if (payment == null)
                throw new ArgumentNullException(nameof(payment));
            this._context.Payments.Remove(payment);
        }

        public Payment Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.Payments
                .Include(p => p.User)
                .FirstOrDefault(p => p.ID == id);
        }

        public ICollection<Payment> GetAll()
        {
            return this._context.Payments
                .Include(p => p.User)
                .ToList();
        }

        public async Task<ICollection<Payment>> GetAllAsync()
        {
            return await this._context.Payments
                .Include(p => p.User)
                .ToListAsync();
        }

        public ICollection<Payment> GetAllEmpty()
        {
            return this._context.Payments
                .ToList();
        }

        public async Task<ICollection<Payment>> GetAllEmptyAsync()
        {
            return await this._context.Payments
                .ToListAsync();
        }

        public async Task<Payment> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.Payments
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.ID == id);
        }

        public Payment GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.Payments
                .FirstOrDefault(p => p.ID == id);
        }

        public async Task<Payment> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.Payments
                .FirstOrDefaultAsync(p => p.ID == id);
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }

        public void Update(Payment obj)
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