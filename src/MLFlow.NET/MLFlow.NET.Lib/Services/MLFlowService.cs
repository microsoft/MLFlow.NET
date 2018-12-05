using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MLFlow.NET.Lib.Contract;
using MLFlow.NET.Lib.Model;
using MLFlow.NET.Lib.Model.Responses.Experiment;

namespace MLFlow.NET.Lib.Services
{
    public class MLFlowService : IMLFlowService
    {
        private readonly IOptions<MLFlowConfiguration> _config;
        private readonly IHttpService _httpService;

        public MLFlowService(IOptions<MLFlowConfiguration> config,
            IHttpService httpService)
        {
            _config = config;
            _httpService = httpService;
        }
        public async Task<CreateResponse> CreateExperiment(
            string name, 
            string artifact_location = null)
        {
            var response = await _httpService.Post<CreateResponse>(_getPath(MLFlowAPI.Experiments.BasePath, MLFlowAPI.Experiments.Create),
                _getParameters(("name", name), ("artifact_location", artifact_location)));
            return response;
        }

        string _getPath(string basePart, string method)
        {
            return $"{basePart}/{method}";
        }

        private Dictionary<string, string> _getParameters(params (string name, string value)[] items)
        {
            return items.Where(i => 
                !string.IsNullOrWhiteSpace(i.name) 
                && !string.IsNullOrWhiteSpace(i.value))
                .ToDictionary(i => i.name, i => i.value);
        }
    }
}
