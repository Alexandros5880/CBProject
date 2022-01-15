using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Areas.Messenger.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(int? id);
        Task DeleteAsync(int? id);
        T Get(int? id);
        Task<T> GetAsync(int? id);
        T GetEmpty(int? id);
        Task<T> GetEmptyAsync(int? id);
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        ICollection<T> GetAllEmpty();
        Task<ICollection<T>> GetAllEmptyAsync();
        IQueryable<T> GetAllQueryable();
        void Save();
        Task<int> SaveAsync();
    }
}
