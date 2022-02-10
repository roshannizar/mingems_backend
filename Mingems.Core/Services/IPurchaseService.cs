using Mingems.Core.Models;
using Mingems.Shared.Api.Models;
using Mingems.Shared.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mingems.Core.Services
{
    public interface IPurchaseService : IBaseService<Purchase>
    {
        Task<IEnumerable<Purchase>> GetInventories();
        Task<Purchase> GetInventory(string Id);
        Task<IEnumerable<Purchase>> SearchInventory(SearchFilterModel searchFilterModel);
        Task DeleteInventoryAsync(string Id);
    }
}
