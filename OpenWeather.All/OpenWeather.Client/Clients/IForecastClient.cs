using OpenWeather.Client.Common;
using OpenWeather.Client.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Client.Clients
{
    public interface IForecastClient: IDisposable
    {
        Task<ForecastResponse> GetByName(string cityName, MetricSystem metric = MetricSystem.Internal);

        Task<ForecastResponse> GetById(int cityId, MetricSystem metric = MetricSystem.Internal);
    }
}
