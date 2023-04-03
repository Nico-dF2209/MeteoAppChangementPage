using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;

namespace MeteoApp.Models
{
    public class CitySearchResult
    {
        public ObservableCollection<City> SearchResult { get; set; } = new();

        private RestClient _client;

        public CitySearchResult()
        {
            _client = new RestClient("https://api.openweathermap.org/geo/1.0/");
        }
        public async void SearchCity(string cityName)
        {
            SearchResult.Clear();

            RestRequest request = new RestRequest("direct");
            request.AddParameter("q", cityName);
            request.AddParameter("limit", 20);
            request.AddParameter("appid", "6e40086c00b5a60000548653739699dc");

            RestResponse response = await _client.GetAsync(request);
            if(response.IsSuccessful)
            {
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;

                JsonDocument doc=JsonDocument.Parse(response.Content);
                JsonElement root = doc.RootElement;
                for(int i = 0; i<root.GetArrayLength(); i++)
                {
                    City city = JsonSerializer.Deserialize<City>(root[i], options);
                    SearchResult.Add(city);
                }
            }

        }
    }
}
