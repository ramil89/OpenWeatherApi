using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenWeather.Client.Clients;
using OpenWeather.Client.Common;
using OpenWeather.Client.Models;
using OpenWeather.Client.Requests;

namespace OpenWeather.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IForecastClient _forecastClient;

        private readonly IRequestFactory _requestFactory;

        public WeatherController(IForecastClient forecastClient, IRequestFactory requestFactory)
        {
            _forecastClient = forecastClient;
            _requestFactory = requestFactory;
        }

        /// <summary>
        /// Retrieves forecast by provided city name
        /// </summary>
        /// <param name="cityName">city name</param>
        /// <param name="metric">Metrics: Internal, Metric or Imperial</param>
        /// <returns></returns>
        [HttpGet("forecast")]
        [ProducesResponseType(typeof(ForecastResponse), 200)]
        public async Task<ForecastResponse> Get([FromQuery(Name ="q")]string cityName, [FromQuery(Name = "units")]MetricSystem metric) 
        {
            var result = await _forecastClient.Get(_requestFactory.GetRequest(cityName), metric);

            if (result.StatusCode != 200)
                throw new Exception($"Invalid request {result.StatusCode}");

            return result;
        }

        /// <summary>
        /// Default startup address.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            return "Forecast Api";
        }
    }
}
