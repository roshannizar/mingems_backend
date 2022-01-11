using Microsoft.EntityFrameworkCore;
using Mingems.Core.SPModels;
using Mingems.Infrastructure.DbContexts;
using Mingems.Report.Interfaces;
using System.Threading.Tasks;

namespace Mingems.Report.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly MingemsDbContext context;

        public DashboardService(MingemsDbContext context)
        {
            this.context = context;
        }

        public async Task<DashboardModel> GetDashboardAsync()
        {
            var investorsCount = await context.SPDashboard.FromSqlRaw("exec InvestorsCount").ToListAsync();
            var inventoryCount = await context.SPDashboard.FromSqlRaw("exec InventoriesCount").ToListAsync();
            var customerCount = await context.SPDashboard.FromSqlRaw("exec CustomerCount").ToListAsync();

            return new DashboardModel()
            {
                TotalCustomers = customerCount[0].count,
                TotalInvestor = investorsCount[0].count,
                TotalStocks = inventoryCount[0].count
            };
        }
    }
}

