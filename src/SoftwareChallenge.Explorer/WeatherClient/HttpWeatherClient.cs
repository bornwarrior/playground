using System;

namespace SoftwareChallenge.Explorer.WeatherClient
{
    public class HttpWeatherClient
    {
        private string url;
        private string appKey;
        public HttpWeatherClient(string url, string appKey)
        {
            if(String.IsNullOrWhiteSpace(url)
            || String.IsNullOrWhiteSpace(appKey))
            {
                throw new ArgumentNullException();
            }

        }
    }

}