using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using MLFlow.NET.Lib.Model;
using MLFlow.NET.Lib.Services;

namespace MLFlow.NET.Lib
{
    public static class MLFlowNetServiceCollectionExtensions
    {
        public static void AddMFlowNet(this IServiceCollection services)
        {
            new ServiceHost().Configure(services);
        }
    }
}
