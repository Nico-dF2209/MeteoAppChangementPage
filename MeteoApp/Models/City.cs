using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeteoApp.Models
{
    public class City
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("country")]
        public string CountryCode { get; set; }
        [JsonPropertyName("lat")]
        public float Latitude { get; set; }
        [JsonPropertyName("lon")]
        public float Longitude { get; set; }

    }
}
