using Asteroids.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asteroids.Domain.Interfaces
{
    public interface INasaService
    {
        AuthenticateResponseModel GetPlanetsInfo(PlanetRequestModel planetInfo, string nasaServiceUrl);
    }
}
