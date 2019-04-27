using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeather.Client.Models
{
    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string IconId { get; set; }
    }
}
