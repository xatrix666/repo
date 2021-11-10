using Asteroids.Application.DTOs;
using Asteroids.Domain.Models;
using AutoMapper;

namespace Asteroids.Application.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthenticateRequestModel, AuthenticateRequestDto>().ReverseMap();
            CreateMap<AuthenticateResponseModel, AuthenticateResponseDto>().ReverseMap();
            CreateMap<PlanetRequestModel, PlanetRequestDto>().ReverseMap();
        }
    }
}
