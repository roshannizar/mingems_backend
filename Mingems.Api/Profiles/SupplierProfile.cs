using AutoMapper;
using Mingems.Api.Dtos.Suppliers;
using Mingems.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mingems.Api.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, CreateSupplierDto>().ReverseMap();
            CreateMap<Supplier, SupplierDto>().ReverseMap();
        }
    }
}
