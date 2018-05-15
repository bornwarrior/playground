using System;
using SoftwareChallenge.Explorer.Models.CityWeather;

namespace SoftwareChallenge.Explorer.WeatherClient
{
    public interface IWeatherClient
    {
        CityWeather GetCityWeather(string country, string cityName);
    }

}