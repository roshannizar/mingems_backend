using Mingems.Core.Models;
using Mingems.Shared.Api.Models;
using Mingems.Shared.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mingems.Core.Services
{
    public interface IInventoryService : IBaseService<Inventory>
    {
        Task<Inventory> GetInventoryByPurchaseId(string Id);
        Task<IEnumerable<Inventory>> SearchInventory(SearchFilterModel searchFilterModel);
    }
}
