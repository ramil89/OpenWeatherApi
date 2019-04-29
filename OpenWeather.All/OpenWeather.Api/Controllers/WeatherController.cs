using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenWeather.Client.Clients;
using OpenWeather.Client.Common;
using OpenWeather.Client.Models;

namespace OpenWeather.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IForecastClient _forecastClient;

        public WeatherController(IForecastClient forecastClient)
        {
            _forecastClient = forecastClient;
        }

        [HttpGet("forecast")]
        public async Task<ForecastResponse> Get([FromQuery(Name ="q")]string cityName, [FromQuery(Name = "units")]MetricSystem metric) 
        {
            var result = await _forecastClient.GetByName(cityName, metric);

            if (result.StatusCode != 200)
                throw new Exception($"Invalid request {result.StatusCode}");

            return result;
        }

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
