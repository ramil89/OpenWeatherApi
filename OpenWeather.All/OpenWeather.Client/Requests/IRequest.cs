using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeather.Client.Requests
{
    public interface IRequest 
    {
        string GetQueryString();
    }
}
