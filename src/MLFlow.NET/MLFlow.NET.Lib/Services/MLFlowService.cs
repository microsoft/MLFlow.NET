using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MLFlow.NET.Lib.Contract;
using MLFlow.NET.Lib.Model;

namespace MLFlow.NET.Lib.Services
{
    public class MLFlowService : IMLFlowService
    {
        private readonly IOptions<MLFlowConfiguration> _config;

        public MLFlowService(IOptions<MLFlowConfiguration> config)
        {
            _config = config;
        }
        public async Task<int> CreateExperiment(
            string name, 
            string artifact_location = null)
        {
            return 0;
        }
    }
}
