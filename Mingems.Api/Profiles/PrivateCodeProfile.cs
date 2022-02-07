using AutoMapper;
using Mingems.Api.Dtos.PrivateCodes;
using Mingems.Core.Models;

namespace Mingems.Api.Profiles
{
    public class PrivateCodeProfile : Profile
    {
        public PrivateCodeProfile()
        {
            CreateMap<PrivateCode, PrivateCodeDto>().ReverseMap();
            CreateMap<PrivateCode, CreatePrivateCodeDto>().ReverseMap();
            CreateMap<PrivateCode, UpdatePrivateCodeDto>().ReverseMap();
        }
    }
}
