using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mingems.Shared.Service
{
    public interface IBaseService<T>
    {
        Task CreateAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(string Id);
        Task<T> GetAsync(string Id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
