using AutoMapper;
using Mingems.Api.Dtos.Investments;
using Mingems.Core.Models;

namespace Mingems.Api.Profiles
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile()
        {
            CreateMap<Investment, CreateInvestmentDto>().ReverseMap();
            CreateMap<Investment, UpdateInvestmentDto>().ReverseMap();
            CreateMap<Investment, InvestmentDto>().ReverseMap();
        }
    }
}
