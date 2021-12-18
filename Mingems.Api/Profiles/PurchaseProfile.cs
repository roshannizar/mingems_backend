using AutoMapper;
using Mingems.Api.Dtos.Purchases;
using Mingems.Core.Models;

namespace Mingems.Api.Profiles
{
    public class PurchaseProfile : Profile
    {
        public PurchaseProfile()
        {
            CreateMap<Purchase, PurchaseDto>().ReverseMap();
            CreateMap<Purchase, CreatePurchaseDto>().ReverseMap();
            CreateMap<Purchase, UpdatePurchaseDto>().ReverseMap();

            CreateMap<Investment, PurchaseInvestmentDto>().ReverseMap();

            CreateMap<Supplier, PurchaseSupplierDto>().ReverseMap();
        }
    }
}
