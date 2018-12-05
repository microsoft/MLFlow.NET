using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MLFlow.NET.Lib.Contract;
using MLFlow.NET.Lib.Model;
using MLFlow.NET.Lib.Services;

namespace MLFlow.NET.Lib
{
    

    public class ServiceHost : IServiceHost
    {
        public IServiceCollection Services { get; private set; }
        public IServiceProvider ServiceProvier { get; private set; }
        public ServiceHost()
        {
            var services = new ServiceCollection();
        }

        public ServiceHost Configure(IServiceCollection services)
        {
            services.AddSingleton<IMLFlowService, MLFlowService>();
            services.AddSingleton<IHttpService, HttpService>();
            return this;
        }

        public IServiceProvider Build()
        {
            ServiceProvier = Services.BuildServiceProvider();
            return ServiceProvier;
        }
    }
}
