using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SoftwareChallenge.Explorer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             //   .ConfigureAppConfiguration(AddAppConfiguration)
                .ConfigureLogging(builder => builder.AddFile())
                .UseStartup<Startup>()
                .Build();

        // public static void AddAppConfiguration(
        //         WebHostBuilderContext hostingContext,
        //         IConfigurationBuilder config)
        // {
        //     var env = hostingContext.HostingEnvironment;
        //     config.SetBasePath(env.ContentRootPath)
        //         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        // }
    }
}
