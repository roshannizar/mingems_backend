using Mingems.Core.Models;
using Mingems.Shared.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mingems.Core.Services
{
    public interface IOrderService: IBaseService<Order>
    {
        Task<IEnumerable<Order>> GetOrderByStatus(int status);
    }
}
