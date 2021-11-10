using Asteroids.Application.DTOs;
using Asteroids.Application.Helpers;
using Asteroids.Domain.Interfaces;
using Asteroids.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Asteroids.Application.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticateRequestDto request)
        {
            var authenticateRequestModel = _mapper.Map<AuthenticateRequestModel>(request);

            var response = _userService.Authenticate(authenticateRequestModel, _appSettings.Secret);

            var authenticateRequestDto = _mapper.Map<AuthenticateResponseDto>(response);

            if (authenticateRequestDto == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(authenticateRequestDto);
        }
    }
}
