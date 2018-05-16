using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SoftwareChallenge.Explorer.WeatherClient;

namespace SoftwareChallenge.Explorer
{
    public class Startup
    {
        private ILogger logger;
        private ILoggerFactory loggerFactory;
        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            this.loggerFactory = loggerFactory;
            this.logger = this.loggerFactory.CreateLogger("Startup");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            //TODO from config
            string url = "http://api.openweathermap.org/data/2.5/weather";
            string appkey = "5eeccbf0617f7a28275ab74a8f503243";

            services.AddSingleton<IWeatherClient>(s => new HttpWeatherClient(url, appkey));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
