namespace Mingems.Api.Dtos.Purchases
{
    public class UpdatePurchaseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string InvestorId { get; set; }
        public decimal UnitPrice { get; set; }
        public string SupplierId { get; set; }
        public decimal ExportCost { get; set; }
    }
}
