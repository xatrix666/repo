using System;
using System.ComponentModel.DataAnnotations;

namespace Asteroids.Application.DTOs
{
    public class PlanetRequestDto
    {
        [Required]
        public string Planet { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Order { get; set; }

        public string TypeOrder { get; set; }

        public int Nrp { get; set; }

        public int Cp { get; set; }
    }
}
