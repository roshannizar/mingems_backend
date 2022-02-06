namespace Mingems.Shared.Api.Models
{
    public class SearchFilterModel
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string InvestorName { get; set; }
        public string InvestorRefId { get; set; }
        public string Measurement { get; set; }
        public string Weight { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
