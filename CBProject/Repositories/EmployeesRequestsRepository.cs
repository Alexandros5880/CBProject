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
    public class EmployeesRequestsRepository : IRepository<EmployeeRequest>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public EmployeesRequestsRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(EmployeeRequest obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            obj.CReatedDate = DateTime.Today;
            this._context.EmployeesRequests.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.EmployeesRequests.FirstOrDefault(e => e.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.EmployeesRequests.Remove(obj);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.EmployeesRequests.FirstOrDefaultAsync(e => e.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.EmployeesRequests.Remove(obj);
        }
        public EmployeeRequest Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.EmployeesRequests
                                        .Include(e => e.Role)
                                        .FirstOrDefault(e => e.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ICollection<EmployeeRequest> GetAll()
        {
            return this._context.EmployeesRequests
                                        .Include(e => e.Role)
                                        .ToList();
        }
        public async Task<ICollection<EmployeeRequest>> GetAllAsync()
        {
            return await this._context.EmployeesRequests
                                            .Include(e => e.Role)
                                            .ToListAsync();
        }
        public ICollection<EmployeeRequest> GetAllEmpty()
        {
            return this._context.EmployeesRequests
                                        .ToList();
        }
        public async Task<ICollection<EmployeeRequest>> GetAllEmptyAsync()
        {
            return await this._context.EmployeesRequests
                                            .ToListAsync();
        }
        public IQueryable<EmployeeRequest> GetAllQueryable()
        {
            return this._context.EmployeesRequests;
        }
        public async Task<EmployeeRequest> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.EmployeesRequests
                                        .Include(e => e.Role)
                                        .FirstOrDefaultAsync(e => e.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public EmployeeRequest GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.EmployeesRequests
                                        .FirstOrDefault(e => e.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public async Task<EmployeeRequest> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj =  await this._context.EmployeesRequests
                                        .Include(e => e.Role)
                                        .FirstOrDefaultAsync(e => e.ID == id);
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
        public void Update(EmployeeRequest obj)
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