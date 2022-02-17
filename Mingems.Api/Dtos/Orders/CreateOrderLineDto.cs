namespace Mingems.Api.Dtos.Orders
{
    public class CreateOrderLineDto
    {
        public string ProductId { get; set; }
        public decimal SoldPrice { get; set; }
    }
}
