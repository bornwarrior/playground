using System;

namespace SoftwareChallenge.Explorer.WeatherClient
{
    public interface IWeatherClient
    {
        string GetCityWeather(string country, string cityName);
    }

}