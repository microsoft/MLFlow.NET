using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace MLFlow.NET.Lib.Contract
{
    public interface IServiceHost
    {
        IServiceCollection Services { get; }
        IServiceProvider ServiceProvier { get; }
        ServiceHost Configure(IServiceCollection services = null);
        IServiceProvider Build();
    }
}
