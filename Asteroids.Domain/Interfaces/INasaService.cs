using Asteroids.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asteroids.Domain.Interfaces
{
    public interface INasaService
    {
        List<PlanetResponseModel> GetPlanetsInfo(PlanetRequestModel planetInfo, string nasaServiceUrl);
    }
}
