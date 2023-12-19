// See https://aka.ms/new-console-template for more information

using ConsoleToWebAPI;
using Microsoft.Extensions.Hosting;
using System;

//Console.WriteLine("Hello, World!");

namespace ConsoleToWebAPI
{ 
    class Program
    { 
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webHost =>
                    {
                        webHost.UseStartup<Startup>();
                    });
        }

    }
}