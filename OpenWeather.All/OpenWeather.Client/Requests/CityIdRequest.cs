using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeather.Client.Requests
{
    public class CityIdRequest : IRequest
    {
        private string _queryString;

        public CityIdRequest(int cityId)
        {
            _queryString = $"id={cityId}";
        }

        public string GetQueryString()
        {
            return _queryString;
        }
    }
}
