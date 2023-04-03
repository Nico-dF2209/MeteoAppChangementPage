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
        public ObservableCollection<Meteo> SearchMeteos { get; set; } = new();

        private RestClient _restClient;

        public MeteoCity(float lat, float lon)
        {
            _restClient = new RestClient("https://api.openweathermap.org/data/2.5/");
            SearchMeteo(lat, lon);
        }

        public async void SearchMeteo(float latitude, float longitude)
        {
            SearchMeteos.Clear();

            RestRequest request = new RestRequest("wheather");
            request.AddParameter("lat", latitude);
            request.AddParameter("lon", longitude);
            request.AddParameter("appid", "6e40086c00b5a60000548653739699dc");
            request.AddParameter("units", "metric");

            RestResponse response = await _restClient.GetAsync(request);

            if (response.IsSuccessful)
            {
                JsonSerializerOptions options = new();
                options.PropertyNameCaseInsensitive = true;

                JsonDocument doc = JsonDocument.Parse(response.Content);
                JsonElement root = doc.RootElement;
                Meteo meteo = JsonSerializer.Deserialize<Meteo>(root, options);
                SearchMeteos.Add(meteo);
            }

        }
    }
}
