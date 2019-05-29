using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeather.Client.Requests
{
    public class ZipCodeRequest : IRequest
    {
        private string _queryString;

        public ZipCodeRequest(string countryCode, string zipCode)
        {
            _queryString = $"zip={zipCode},{countryCode}";
        }

        public string GetQueryString()
        {
            return _queryString;
        }
    }
}
