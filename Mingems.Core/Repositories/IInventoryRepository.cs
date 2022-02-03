using Mingems.Core.Models;
using Mingems.Shared.Repository;
using System.Threading.Tasks;

namespace Mingems.Core.Repositories
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<Inventory> GetInventoryByPurchaseId(string Id);
    }
}
