﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var response = await _httpService.Post<CreateResponse>(_getPath(MLFlowAPI.Experiments.BasePath, MLFlowAPI.Experiments.Create),
                _getParameters(("name", name), ("artifact_location", artifact_location)));
            return response;
        }

        public async Task<RunResponse> CreateRun(int experiment_id,
                                        string user_id,
                                        string run_name,
                                        SourceType source_type,
                                        string source_name,
                                        string entry_point_name,
                                        long start_time,
                                        string source_version,
                                        RunTag[] tags)

        {
            var response = await _httpService.Post<RunResponse>(_getPath(MLFlowAPI.Runs.BasePath, MLFlowAPI.Runs.Create),
                
                _getParameters(
                    ("experiment_id", experiment_id.ToString()),
                    ("user_id", user_id),
                    ("run_name", run_name),
                    ("source_type", source_type.ToString()),
                    ("source_name", source_name),
                    ("entry_point_name", entry_point_name),
                    ("start_time", start_time.ToString()),
                    ("source_version", source_version),
                    ("tags", tags?.ToString())
                    ));
            return response;
        }

        public async Task<LogMetric> LogMetric(string run_uuid,
            string key, float value, long? timeStamp = null)
        {
            if (!timeStamp.HasValue)
            {
                timeStamp = _getTimestamp();
            }

            var response = await _httpService.Post<LogMetric>(
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
