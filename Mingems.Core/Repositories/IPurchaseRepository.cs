using Mingems.Core.Models;
using Mingems.Shared.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mingems.Core.Repositories
{
    public interface IPurchaseRepository: IRepository<Purchase>
    {
        Task<IEnumerable<Purchase>> GetInventories();
        Task<Purchase> GetInventory(string Id);
    }
}
