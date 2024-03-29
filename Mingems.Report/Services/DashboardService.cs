﻿using Microsoft.EntityFrameworkCore;
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
            var purchaseCount = await context.SPDashboard.FromSqlRaw("exec PurchaseCount").ToListAsync();
            var supplierCount = await context.SPDashboard.FromSqlRaw("exec SupplierCount").ToListAsync();
            var salesCount = await context.SPDashboard.FromSqlRaw("exec SalesCount").ToListAsync();
            var pendingSalesCount = await context.SPDashboard.FromSqlRaw("exec PendingSalesCount").ToListAsync();
           
            var topInvestors = await context.TopInvestors.FromSqlRaw("exec TopInvestors").ToListAsync();
            var topCustomers = await context.TopCustomers.FromSqlRaw("exec TopCustomers").ToListAsync();


            return new DashboardModel()
            {
                TotalCustomers = customerCount.Count >0 ? customerCount[0].Count : 0,
                TotalInvestor = investorsCount.Count > 0 ? investorsCount.Count : 0,
                TotalStocks = inventoryCount.Count > 0 ? inventoryCount[0].Count : 0,
                TotalPurchases = purchaseCount.Count > 0 ? purchaseCount[0].Count : 0,
                TotalSupplier = supplierCount.Count > 0 ? supplierCount[0].Count : 0,
                TotalSales = salesCount.Count > 0 ? salesCount[0].Count : 0,
                TotalPendingSales = pendingSalesCount.Count > 0 ? pendingSalesCount[0].Count : 0,
                Investors = topInvestors,
                Customers = topCustomers
            };
        }
    }
}

