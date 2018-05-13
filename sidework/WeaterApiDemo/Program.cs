using System;
using RestSharp;


namespace WeaterApiDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
             {
                string serviceAppId = "5eeccbf0617f7a28275ab74a8f503243";
                string serviceUrl = "http://api.openweathermap.org/data/2.5/weather";

                var client = new RestClient(serviceUrl);
                var request = new RestRequest("?q={cityName}&appid={appId}", Method.GET);

                request.AddUrlSegment("cityName", "Toronto");
                request.AddUrlSegment("appId", serviceAppId);
                var fullUrl = client.BuildUri(request);
                Console.WriteLine(fullUrl);
                IRestResponse response = client.Execute(request);
                var content = response.Content;
                Console.WriteLine(content);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught Execption {ex.Message}");
            }
        }
    }
}
