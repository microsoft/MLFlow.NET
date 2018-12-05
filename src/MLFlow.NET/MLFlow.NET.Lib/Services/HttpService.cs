using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using MLFlow.NET.Lib.Model;

namespace MLFlow.NET.Lib.Services
{
    public class HttpService
    {
        private readonly IOptions<MLFlowConfiguration> _config;

        public HttpService(IOptions<MLFlowConfiguration> config)
        {
            _config = config;
        }
    }
}
