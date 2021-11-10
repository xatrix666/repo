using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asteroids.Application.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/planet")]
    public class PlanetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
