using AutoMapper;
using Mingems.Api.Dtos.Inventories;
using Mingems.Core.Models;

namespace Mingems.Api.Profiles
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<Purchase, InventoryDto>().ReverseMap();
            CreateMap<Purchase, UpdateInventoryDto>().ReverseMap();

            CreateMap<ImageLines, ImageLinesDto>().ReverseMap();
            CreateMap<ImageLines, CreateImageLinesDto>().ReverseMap();
            CreateMap<ImageLines, UpdateImageLinesDto>().ReverseMap();

            CreateMap<Investment, InventoryInvestorDto>().ReverseMap();
        }
    }
}
