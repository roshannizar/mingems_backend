using Mingems.Core.Models;
using Mingems.Shared.Service;
using System.Threading.Tasks;

namespace Mingems.Core.Services
{
    public interface IInventoryService : IBaseService<Inventory>
    {
        Task<Inventory> GetInventoryByPurchaseId(string Id);
    }
}
