using AutoMapper;
using Mingems.Api.Dtos.Subscriptions;
using Mingems.Core.Models;

namespace Mingems.Api.Profiles
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<Subscription, SubscriptionDto>().ReverseMap();
            CreateMap<Subscription, CreateSubscriptionDto>().ReverseMap();
            CreateMap<Subscription, UpdateSubscriptionDto>().ReverseMap();
        }
    }
}
