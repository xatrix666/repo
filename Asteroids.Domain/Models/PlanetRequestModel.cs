using System;

namespace Asteroids.Domain.Models
{
    public class PlanetRequestModel
    {
        public string Planet { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Order { get; set; }

        public string TypeOrder { get; set; }

        public int Nrp { get; set; }

        public int Cp { get; set; }
    }
}
