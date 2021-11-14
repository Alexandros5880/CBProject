using System.Collections.Generic;
using System.Threading.Tasks;

namespace CBProject.Repositories.Interfaces
{
    public interface IRepository<T> // TODO: Implement this interface to every repository
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(int? id);
        T Get(int? id);
        Task<T> GetAsync(int? id);
        T GetEmpty(int? id);
        Task<T> GetEmptyAsync(int? id);
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        ICollection<T> GetAllEmpty();
        Task<ICollection<T>> GetAllEmptyAsync();
        void Save();
        Task<int> SaveAsync();
    }
}
