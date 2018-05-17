using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftwareChallenge.Explorer.WeatherClient;
using SoftwareChallenge.Explorer.Models.CityWeather;
using Microsoft.Extensions.Logging;


namespace SoftwareChallenge.Explorer.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private readonly ILogger<WeatherController> logger;
        private readonly IWeatherClient wClient;

        public WeatherController(ILogger<WeatherController> logger, IWeatherClient weaterClient)
        {
            this.logger = logger;
            wClient = weaterClient;
        }

        [HttpGet("{cityName}")]
        public string Get(string cityName)
        {
            //TODO validate cityName

            //for Canadain city now
            CityWeather resultWeather = wClient.GetCityWeather("CA",cityName);

            if (resultWeather != null)
            {
                double temprature = 300 - resultWeather.main.temp;
                temprature = Math.Round(temprature, 2);
                return $"{cityName.ToUpper()}: Temprature: {temprature} °C Description: {resultWeather.weather[0].description }";

            }
                
            else
            {
                return $"Unable to Retrive Weather for {cityName}";
            }
            
        }

    }
}
