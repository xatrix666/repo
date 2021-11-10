using Asteroids.Application.DTOs;
using Asteroids.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asteroids.Application.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthenticateRequestModel, AuthenticateRequestDto>().ReverseMap();
            CreateMap<AuthenticateResponseModel, AuthenticateResponseDto>().ReverseMap();
        }
    }
}
