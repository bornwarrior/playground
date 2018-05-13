using System;
using Xunit;
using SoftwareChallenge.Explorer.WeatherClient;

namespace SoftwareChallenge.Explorer.Tests
{
    public class WeatherClientTest
    {
        [Fact]
        public void ValidateUrlThrowsException()
        {
            Assert.Throws<ArgumentNullException>( () =>
            new HttpWeatherClient(null,"somekey"));

        }
    }
}
