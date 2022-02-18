using System.Collections.Generic;

namespace Mingems.Core.SPModels
{
    public class DashboardModel
    {
        public int TotalStocks { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalInvestor { get; set; }
        public int TotalPurchases { get; set; }
        public int TotalSupplier { get; set; }
        public int TotalSales { get; set; }
        public int TotalPendingSales { get; set; }
        public List<TopInvestors> Investors { get; set; }
        public List<TopCustomers> Customers { get; set; }
    }

    public class TopInvestors
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Fund { get; set; }
        public decimal Balance { get; set; }
    }

    public class TopCustomers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
