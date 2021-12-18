using AutoMapper;
using Mingems.Api.Dtos.Suppliers;
using Mingems.Core.Models;

namespace Mingems.Api.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, CreateSupplierDto>().ReverseMap();
            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<Supplier, UpdateSupplierDto>().ReverseMap();
        }
    }
}
