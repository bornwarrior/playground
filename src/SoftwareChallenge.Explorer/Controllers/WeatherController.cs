﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftwareChallenge.Explorer.WeatherClient;
using Microsoft.Extensions.Logging;


namespace SoftwareChallenge.Explorer.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
          private readonly ILogger<WeatherController> logger;

          public WeatherController(ILogger<WeatherController> logger)
          {
              this.logger = logger;
          }
        // GET api/values
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "Hello", "World" };
        // }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            logger.LogInformation($"Get Called with {id}");
            return "Hello World";
        }

        // [HttpGet("{cityname}")]
        // public string GetWeather(int id)
        // {
            
        // }

        // // POST api/values
        // [HttpPost]
        // public void Post([FromBody]string value)
        // {
        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody]string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
