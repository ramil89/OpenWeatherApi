using OpenWeather.Client.Common;
using OpenWeather.Client.Models;
using OpenWeather.Client.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Client.Clients
{
    public interface IForecastClient: IDisposable
    {
        Task<ForecastResponse> Get(IRequest request, MetricSystem metric = MetricSystem.Internal);
    }
}
