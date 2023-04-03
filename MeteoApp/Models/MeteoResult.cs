using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace MeteoApp.Models
{
   
    public class MeteoCity
    {
        //public ObservableCollection<Meteo> SearchMeteos { get; set; } = new();

        private static RestClient _restClient = new RestClient("https://api.openweathermap.org/data/2.5/");

        public MeteoCity(float lat, float lon)
        {
           // SearchMeteo(lat, lon);


        }



        public static async Task<Meteo> SearchMeteo(float latitude, float longitude)
        {
            RestRequest request = new RestRequest("weather");
            request.AddParameter("lat", latitude);
            request.AddParameter("lon", longitude);
            request.AddParameter("appid", "6e40086c00b5a60000548653739699dc");
            request.AddParameter("units", "metric");

            RestResponse response = await _restClient.GetAsync(request);

            if (response.IsSuccessful)
            {
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;

                return JsonSerializer.Deserialize<Meteo>(response.Content, options);
            }
            return null;

        }
    }
}

