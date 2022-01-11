using Mingems.Core.SPModels;
using System.Threading.Tasks;

namespace Mingems.Report.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardModel> GetDashboardAsync();
    }
}
