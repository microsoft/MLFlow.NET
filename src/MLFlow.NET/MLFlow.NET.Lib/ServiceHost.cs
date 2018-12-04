using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
namespace MLFlow.NET.Lib
{
    public class ServiceHost
    {
        public ServiceCollection Services { get; private set; }
        public IServiceProvider ServiceProvier { get; private set; }
        public ServiceHost()
        {
            var services = new ServiceCollection();
        }

        public ServiceHost Configure()
        {

            return this;
        }

        public ServiceHost Build()
        {

            ServiceProvier = Services.BuildServiceProvider();
            return this;
        }
    }
}
