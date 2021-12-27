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
    public class OrdersRepository : IRepository<Order>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public OrdersRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(Order obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.Orders.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var order = this._context.Orders
                                .FirstOrDefault(o => o.ID == id);
            if (order == null)
                throw new ArgumentNullException(nameof(order));
            this._context.Orders.Remove(order);
        }
        public Order Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.Orders
                        .Include(o => o.User)
                        .Include(o => o.SubscriptionPackage)
                        .FirstOrDefault(o => o.ID == id);
        }
        public ICollection<Order> GetAll()
        {
            return this._context.Orders
                        .Include(o => o.User)
                        .Include(o => o.SubscriptionPackage)
                        .ToList();
        }
        public async Task<ICollection<Order>> GetAllAsync()
        {
            return await this._context.Orders
                                .Include(o => o.User)
                                .Include(o => o.SubscriptionPackage)
                                .ToListAsync();
        }
        public ICollection<Order> GetAllEmpty()
        {
            return this._context.Orders.ToList();
        }
        public async Task<ICollection<Order>> GetAllEmptyAsync()
        {
            return await this._context.Orders.ToListAsync();
        }
        public IQueryable<Order> GetAllQueryable()
        {
            return this._context.Orders;
        }
        public async Task<Order> GetAsync(int? id)
        {
            return await this._context.Orders
                        .Include(o => o.User)
                        .Include(o => o.SubscriptionPackage)
                        .FirstOrDefaultAsync(o => o.ID == id);
        }
        public Order GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.Orders.FirstOrDefault(o => o.ID == id);
        }
        public async Task<Order> GetEmptyAsync(int? id)
        {
            return await this._context.Orders.FirstOrDefaultAsync(o => o.ID == id);
        }
        public void Save()
        {
            this._context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
        public void Update(Order obj)
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