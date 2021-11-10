using Asteroids.Domain.Interfaces;
using Asteroids.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Asteroids.Domain.Implementations
{
    public class NasaService : INasaService
    {
        public AuthenticateResponseModel GetPlanetsInfo(PlanetRequestModel planetInfo, string nasaServiceUrl)
        {
            var jsonNasa = CallWebServices(String.Format(nasaServiceUrl, planetInfo.StartDate.ToString("yyyy-MM-dd"), planetInfo.EndDate.ToString("yyyy-MM-dd")));

            var nasaResponseModel = JsonConvert.DeserializeObject<NasaResponseModel>(jsonNasa);

            return null;
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
    }
}
