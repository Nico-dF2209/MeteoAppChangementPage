using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeteoApp.Models
{
    public struct Coord
    {
        public float lon;
        public float lat;
    }
    public struct Weather
    {
        public int id;
        public string main;
        public string description;
        public string icon;
    }

    public struct Main
    {
        public float temp;

    }
    public struct Wind
    {
        public float speed;

    }
    public struct Clouds
    {
        public float all;
    }
    public struct Rain
    {
        public float oneh;

    }
    public struct Sys
    {
        public string country;
    }


    public class Meteo
    {
        [JsonPropertyName("coord")]
        public Coord Coord { get; set; }
        [JsonPropertyName("weather")]
        public Weather[] Weather { get; set; }
        [JsonPropertyName("main")]
        public Main Main { get; set; }
        [JsonPropertyName("visibility")]
        public Visibility Visibility { get; set; }
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }
        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }
        [JsonPropertyName("rain")]
        public Rain Rain { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("country")]
        public Sys sys { get; set; }


    }
}
