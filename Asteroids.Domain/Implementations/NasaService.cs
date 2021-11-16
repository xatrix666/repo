using Asteroids.Domain.Interfaces;
using Asteroids.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Asteroids.Domain.Implementations
{
    public class NasaService : INasaService
    {
        public List<PlanetResponseModel> GetPlanetsInfo(PlanetRequestModel planetInfo, string nasaServiceUrl)
        {
            var jsonNasa = CallWebServices(String.Format(nasaServiceUrl, planetInfo.StartDate.ToString("yyyy-MM-dd"), planetInfo.EndDate.ToString("yyyy-MM-dd")));
            var asteroidsInfolist = DeserializeToAsteoridsList(jsonNasa);
            var planetResponse = GeneratePlanetInfoResponse(asteroidsInfolist);
            return planetResponse;
        }

        private string CallWebServices(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                }
            }
            return null;
        }

        private List<AsteroidInfoModel> DeserializeToAsteoridsList(string jsonNasa)
        {
            try
            {
                var jObject = JObject.Parse(jsonNasa);
                var near_earth_objects = jObject["near_earth_objects"];
                var AsteroidsData = near_earth_objects.Children().Children().Children();
                var Asteroidslist = new List<AsteroidInfoModel>();
                foreach (var asteroid in AsteroidsData)
                {
                    var asteroidJson = JsonConvert.SerializeObject(asteroid);
                    var asteroidInfo = JsonConvert.DeserializeObject<AsteroidInfoModel>(asteroidJson);
                    Asteroidslist.Add(asteroidInfo);
                }
                return Asteroidslist;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private List<PlanetResponseModel> GeneratePlanetInfoResponse(List<AsteroidInfoModel> asteroidsInfolist)
        {
            var planetResponseList = new List<PlanetResponseModel>();
            foreach (var asteroidInfo in asteroidsInfolist)
            {
                var planetResponse = new PlanetResponseModel();
                planetResponse.Name = asteroidInfo.Name;

                var diameterEstimatedMin = asteroidInfo.Estimated_diameter.Kilometers.estimated_diameter_min;
                var diameterEstimatedMax = asteroidInfo.Estimated_diameter.Kilometers.estimated_diameter_max;

                planetResponse.Id = asteroidInfo.Id;

                planetResponse.Diameter = diameterEstimatedMin + diameterEstimatedMax / 2;

                planetResponse.Velocity = asteroidInfo.Close_approach_data.Select(a => a.Relative_velocity).Select(v => v.Kilometers_per_hour).FirstOrDefault();

                planetResponse.Date = asteroidInfo.Close_approach_data.Select(a => a.Close_approach_date).FirstOrDefault();

                planetResponse.Planet = asteroidInfo.Close_approach_data.Select(a => a.Orbiting_body).FirstOrDefault();

                planetResponseList.Add(planetResponse);

            }
            return planetResponseList;
        }
    }
}
