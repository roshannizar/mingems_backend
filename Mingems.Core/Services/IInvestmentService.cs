using Mingems.Core.Models;
using Mingems.Shared.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mingems.Core.Services
{
    public interface IInvestmentService : IBaseService<Investment>
    {
        Task<IEnumerable<Investment>> GetUniqueInvestors();
    }
}
