using System;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;



namespace SoftwareChallenge.Explorer.Tests.Integration
{
    public class SimpleIntegrationTests
    {
        private readonly TestServer testServer;
        private readonly HttpClient testClient;

        public SimpleIntegrationTests()
        {
              testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
              testClient = testServer.CreateClient();
        }

        [Fact]
        public async void ForAnIdReceiveHElloWorld()
        {
            //arrange
            int id = 1;
            string expectedResult = "Hello World";
            
            //act
            var getResponse = await testClient.GetAsync($"api/weather/{id}");

            //asert
            getResponse.EnsureSuccessStatusCode();
            

            string actualResult = await getResponse.Content.ReadAsStringAsync();
            Assert.Equal(expectedResult, actualResult);

        }
    }
}
