using System;
using System.Collections.Generic;
using System.Text;

namespace Asteroids.Domain.Models
{
    public class PlanetResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Diameter { get; set; }
        public string Velocity { get; set; }
        public DateTime Date { get; set; }
        public string Planet { get; set; }

    }
}
