using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MLFlow.NET.Lib.Contract;
using MLFlow.NET.Lib.Model;
using MLFlow.NET.Lib.Model.Responses.Experiment;
using MLFlow.NET.Lib.Model.Responses.Run;

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
            var response = await _httpService.Post<CreateResponse, Dictionary<string, string>>(_getPath(MLFlowAPI.Experiments.BasePath, MLFlowAPI.Experiments.Create),
                _getParameters(("name", name), ("artifact_location", artifact_location)));
            return response;
        }

        public async Task<RunResponse> CreateRun(CreateRunRequest request)
        {
            var response = await _httpService.Post<RunResponse, CreateRunRequest>(_getPath(MLFlowAPI.Runs.BasePath, MLFlowAPI.Runs.Create), request);
            return response;
        }


        public async Task<LogMetric> LogMetric(string run_uuid,
            string key, float value, long? timeStamp = null)
        {
            if (!timeStamp.HasValue)
            {
                timeStamp = _getTimestamp();
            }

            var response = await _httpService.Post<LogMetric, Dictionary<string, string>>(
                _getPath(MLFlowAPI.Runs.BasePath,
                    MLFlowAPI.Runs.LogMetric),
                _getParameters(
                    ("run_uuid", run_uuid),
                    ("key", key),
                    ("value", value.ToString()),
                    ("timeStamp", timeStamp.ToString())
                ));

            return response;
        }

        public async Task<LogParam> LogParameter(string run_uuid,
            string key, string value)
        {
            var response = await _httpService.Post<LogParam, Dictionary<string, string>>(
                _getPath(MLFlowAPI.Runs.BasePath,
                    MLFlowAPI.Runs.LogParam),
                _getParameters(
                    ("run_uuid", run_uuid),
                    ("key", key),
                    ("value", value)
                ));

            return response;
        }

        public async Task<ListExperimentsResponse> ListExperiments(ViewType viewtype)
        {


            var response = await _httpService.Get<ListExperimentsResponse, Object>(
                _getPath(MLFlowAPI.Experiments.BasePath, MLFlowAPI.Experiments.List),
                new { viewtype = viewtype.ToString() });

            return response;
        }

        public async Task<GetExperimentResponse> GetExperiment(int experiment_id)
        {
            var response = await _httpService.Get<GetExperimentResponse, Object>(
                _getPath(MLFlowAPI.Experiments.BasePath, MLFlowAPI.Experiments.Get),
                new {experiment_id });

            return response;
        }

        long _getTimestamp()
        {
            return ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
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
