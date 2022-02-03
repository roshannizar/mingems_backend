namespace Mingems.Api.Dtos.Inventories
{
    public class InventoryPurchaseDto
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string InvestorId { get; set; }
        public string Weight { get; set; }
        public string PriceCode { get; set; }
        public string LastPriceCode { get; set; }
    }
}
