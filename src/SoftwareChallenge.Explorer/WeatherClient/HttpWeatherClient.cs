using System;
using SoftwareChallenge.Explorer.Models.CityWeather;
using RestSharp;
using Newtonsoft.Json;

namespace SoftwareChallenge.Explorer.WeatherClient
{
    public class HttpWeatherClient
    {
        private string weatherServiceUrl;
        private string weatherAppKey;
        public HttpWeatherClient(string url, string appKey)
        {
            if(String.IsNullOrWhiteSpace(url)
            || String.IsNullOrWhiteSpace(appKey))
            {
                throw new ArgumentNullException();
            }

            weatherServiceUrl = url;
            weatherAppKey = appKey;

        }

        public CityWeather GetCityWeather(string countryName, string cityName)
        {
             if (String.IsNullOrWhiteSpace(countryName)
            || String.IsNullOrWhiteSpace(cityName))
            {
                throw new ArgumentNullException();
            }

            CityWeather cityWeather = null;

            cityWeather = GetWeatherFromApp(countryName, cityName);

            return cityWeather;
        }

         private CityWeather GetWeatherFromApp(string countryName, string cityName)
        {
            RestClient client = new RestClient(weatherServiceUrl);
            var request = new RestRequest("?q={cityName}&appid={appId}", Method.GET);

            request.AddUrlSegment("cityName", cityName);
            request.AddUrlSegment("appId", weatherAppKey);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                String jsonResponse = response.Content;
                CityWeather cityWeather = JsonConvert.DeserializeObject<CityWeather>(jsonResponse);
                return cityWeather;
            }

            //log error
            return null;
        }
    }

}