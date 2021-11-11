using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Asteroids.Domain.Models
{
    public class AsteroidInfoModel
    {
        public AsteroidInfoModel()
        {
            Close_approach_data = new List<Close_approach_data>();
        }
        public Links links { get; set; }
        public int Id { get; set; }
        public string Neo_reference_id { get; set; }
        public string Name { get; set; }
        public string Nasa_jpl_url { get; set; }
        public decimal Absolute_magnitude_h { get; set; }
        public Estimated_diameter Estimated_diameter { get; set; }
        public bool Is_potentially_hazardous_asteroid { get; set; }
        public List<Close_approach_data> Close_approach_data { get; set; }
        public bool Is_sentry_object { get; set; }

    }

    public class Links
    {
        public string Self { get; set; }
    }

    public class Estimated_diameter
    {
        public Kilometers Kilometers { get; set; }
        public Meters Meters { get; set; }
        public Miles Miles { get; set; }
        public Feet Feet { get; set; }
    }

    public class Kilometers
    {
        public decimal estimated_diameter_min { get; set; }
        public decimal estimated_diameter_max { get; set; }
    }

    public class Meters
    {
        public decimal estimated_diameter_min { get; set; }
        public decimal estimated_diameter_max { get; set; }
    }

    public class Miles
    {
        public decimal estimated_diameter_min { get; set; }
        public decimal estimated_diameter_max { get; set; }
    }

    public class Feet
    {
        public decimal estimated_diameter_min { get; set; }
        public decimal estimated_diameter_max { get; set; }
    }

    public class Close_approach_data
    {
        public DateTime Close_approach_date { get; set; }

        public DateTime Close_approach_date_full { get; set; }

        public long Epoch_date_close_approach { get; set; }

        public Relative_velocity Relative_velocity { get; set; }

        public Miss_distance Miss_distance { get; set; }

        public string Orbiting_body { get; set; }
    }

    public class Relative_velocity
    {
        public string Kilometers_per_second { get; set; }

        public string Kilometers_per_hour { get; set; }

        public string Miles_per_hour { get; set; }

    }

    public class Miss_distance
    {
        public string Astronomical { get; set; }

        public string Lunar { get; set; }

        public string Kilometers { get; set; }

        public string Miles { get; set; }
    }
}
