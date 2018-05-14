using System;
using Xunit;
using SoftwareChallenge.Explorer.WeatherClient;
using SoftwareChallenge.Explorer.Models.CityWeather;

namespace SoftwareChallenge.Explorer.Tests
{
    public class WeatherClientTest
    {
        string serviceAppId = "5eeccbf0617f7a28275ab74a8f503243";
        string serviceUrl = "http://api.openweathermap.org/data/2.5/weather";

        [Fact]
        public void ValidateUrlThrowsException()
        {
            Assert.Throws<ArgumentNullException>( () =>
            new HttpWeatherClient(null,"somekey"));

        }

         [Fact]
        public void ValidateTheCityWeather()
        {
            HttpWeatherClient weatherClient = new HttpWeatherClient(serviceUrl,serviceAppId);
            CityWeather resultWeather =  weatherClient.GetCityWeather("CA","Toronto");
            Assert.Equal("Toronto", resultWeather.name);
        }
    }
}
