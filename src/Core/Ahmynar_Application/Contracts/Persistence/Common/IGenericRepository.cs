using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ahmynar_Application.Contracts.Persistence.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<bool> Exists(int id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
