using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeather.Client.Models
{
    public class ForecastResponse
    {
        [JsonProperty("list")]
        public List<Forecast> Forecast { get; set; }

        [JsonProperty("cnt")]
        public int Count { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("cod")]
        public int StatusCode { get; set; }
    }
}
