using Asteroids.Application.DTOs;
using Asteroids.Application.Helpers;
using Asteroids.Domain.Interfaces;
using Asteroids.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Asteroids.Application.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/asteroids")]
    public class AsteroidsController : ControllerBase
    {        
        private readonly INasaService _nasaService;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public AsteroidsController(INasaService nasaService, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _nasaService = nasaService;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetPlanetsInfo([FromQuery] PlanetRequestDto request)
        {
            var planetRequestModel = _mapper.Map<PlanetRequestModel>(request);

            var planetResponseListModel = _nasaService.GetPlanetsInfo(planetRequestModel, _appSettings.NasaServiceUrl);

            var planetResponseListDto = _mapper.Map<List<PlanetResponseDto>>(planetResponseListModel);

            return Ok(planetResponseListDto);
        }
    }
}
