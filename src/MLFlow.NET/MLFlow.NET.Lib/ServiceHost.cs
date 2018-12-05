using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MLFlow.NET.Lib.Contract;
using MLFlow.NET.Lib.Model;

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
            services.AddSingleton<IMLFlowService, IMLFlowService>();
            
            return this;
        }

        public IServiceProvider Build()
        {
            ServiceProvier = Services.BuildServiceProvider();
            return ServiceProvier;
        }
    }
}
