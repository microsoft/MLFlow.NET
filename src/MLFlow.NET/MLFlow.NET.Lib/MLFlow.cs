using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using MLFlow.NET.Lib.Model;
using MLFlow.NET.Lib.Services;

namespace MLFlow.NET.Lib
{
    public class MLFlowNET
    {
        static ServiceHost _serviceHost = new ServiceHost();

        static MLFlowNET()
        {
            _serviceHost.Configure().Build();
        }
        public static MLFlowService Create(MLFlowConfiguration config)
        {
            
        }
    }
}
