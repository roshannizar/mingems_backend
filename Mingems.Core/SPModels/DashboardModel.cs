using System.Collections.Generic;

namespace Mingems.Core.SPModels
{
    public class DashboardModel
    {
        public int TotalStocks { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalInvestor { get; set; }
        public List<TopInvestors> Investors { get; set; }
    }

    public class TopInvestors
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Fund { get; set; }
        public decimal Balance { get; set; }
    }
}
