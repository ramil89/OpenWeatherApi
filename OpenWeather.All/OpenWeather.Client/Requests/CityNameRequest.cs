using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeather.Client.Requests
{
    public class CityNameRequest: IRequest
    {
        private string _queryString;

        public CityNameRequest(string cityName)
        {
            _queryString = $"q={cityName}"; 
        }

        public string GetQueryString()
        {
            return _queryString;
        }
    }
}
