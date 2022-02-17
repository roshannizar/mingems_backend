using AutoMapper;
using Mingems.Api.Dtos.Orders;
using Mingems.Core.Models;

namespace Mingems.Api.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<OrderLine, CreateOrderLineDto>().ReverseMap();
            CreateMap<OrderLine, OrderLineDto>().ReverseMap();

            CreateMap<Customer, OrderCustomerDto>().ReverseMap();
            CreateMap<Purchase, OrderPurchaseDto>().ReverseMap();
        }
    }
}
