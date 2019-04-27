﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenWeather.Client.Common;
using OpenWeather.Client.Models;

namespace OpenWeather.Client.Clients
{
    public class ForecastClient: IForecastClient
    {
        private readonly OpenWeatherApiSettings _settings;

        private readonly HttpClient _httpClient;

        public ForecastClient(OpenWeatherApiSettings settings)
        {
            _settings = settings;
            _httpClient = new HttpClient();
        }
        
        public async Task<ForecastResponse> GetById(int cityId, MetricSystem metric = MetricSystem.Internal)
        {
            return await GetForecast($"{_settings.ApiUrl}/forecast?id={cityId}&units={metric}&appid={_settings.ApiKey}&mode=json");
        }

        public async Task<ForecastResponse> GetByName(string cityName, MetricSystem metric = MetricSystem.Internal)
        {
            return await GetForecast($"{_settings.ApiUrl}/forecast?q={cityName}&units={metric}&appid={_settings.ApiKey}&mode=json");
        }

        private async Task<ForecastResponse> GetForecast(string url)
        {
            var response = await _httpClient.GetAsync(url);

            var responseResult = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ForecastResponse>(responseResult);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
