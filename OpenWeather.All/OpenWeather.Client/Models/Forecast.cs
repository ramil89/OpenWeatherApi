using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeather.Client.Models
{
    public class Forecast
    {
        [JsonProperty("dt_txt")]
        public DateTime Date { get; set; }  

        [JsonProperty("main")]
        public ForecastData ForecastItems { get; set; }

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; } 

        [JsonProperty("wind")]
        public Wind Wind { get; set; }
    }
}
