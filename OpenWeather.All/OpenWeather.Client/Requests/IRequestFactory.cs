using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeather.Client.Requests
{
    public interface IRequestFactory
    {
        IRequest GetRequest(string cityName);

        IRequest GetRequest(int cityId);

        IRequest GetRequest(string zipCode, string countryCode);
    }
}
