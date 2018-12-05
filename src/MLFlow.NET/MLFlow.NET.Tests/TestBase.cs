using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using MLFlow.NET.Lib;
using MLFlow.NET.Lib.Model;

namespace MLFlow.NET.Tests
{
    public class TestBase
    {
        private IServiceProvider ServiceProvider { get; set; }
        private IServiceCollection ServiceCollection { get; set; }

        public TestBase()
        {
            var builder = new ConfigurationBuilder();
            // tell the builder to look for the appsettings.json file
            builder
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


            var Configuration = builder.Build();


            ServiceCollection = new ServiceCollection();
            ServiceCollection.AddMFlowNet();
            ServiceCollection.Configure<MLFlowConfiguration>(Configuration.GetSection(nameof(MLFlowConfiguration)));

            ServiceProvider = ServiceCollection.BuildServiceProvider();
        }

        public T Resolve<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
