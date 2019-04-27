using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeather.Client.Models
{
    public class ForecastData
    { 
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("temp_min")]
        public double TemperatureMin { get; set; }

        [JsonProperty("temp_max")]
        public double TemperatureMax { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("sea_level")]
        public double PressureSeaLevel { get; set; }

        [JsonProperty("grnd_level")]
        public double PressureGroundLevel { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }
}
