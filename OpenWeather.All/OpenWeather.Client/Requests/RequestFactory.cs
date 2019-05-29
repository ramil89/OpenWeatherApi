using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeather.Client.Requests
{
    public class RequestFactory : IRequestFactory
    {
        public RequestFactory()
        {
        }

        public IRequest GetRequest(string cityName)
        {
            return new CityNameRequest(cityName);
        }

        public IRequest GetRequest(int cityId)
        {
            return new CityIdRequest(cityId);
        }

        public IRequest GetRequest(string zipCode, string countryCode)
        {
            return new ZipCodeRequest(countryCode, zipCode);
        }
    }
}
