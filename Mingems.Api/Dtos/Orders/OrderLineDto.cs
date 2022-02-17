namespace Mingems.Api.Dtos.Orders
{
    public class OrderLineDto
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public virtual OrderPurchaseDto Purchase { get; set; }
        public int Quantity { get; set; }
        public decimal SoldPrice { get; set; }
        public decimal ActualPrice { get; set; }
    }
}
