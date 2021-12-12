﻿using AutoMapper;
using Mingems.Api.Dtos.Users;
using Mingems.Core.Models;

namespace Mingems.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
