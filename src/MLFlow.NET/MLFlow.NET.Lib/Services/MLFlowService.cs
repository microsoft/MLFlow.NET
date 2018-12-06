using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MLFlow.NET.Lib.Contract;
using MLFlow.NET.Lib.Model;
using MLFlow.NET.Lib.Model.Responses.Experiment;
using MLFlow.NET.Lib.Model.Responses.Run;
using Newtonsoft.Json;

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

            //expected  "tags":[{key:'a','value:'b'}]
            string tmptags = "";
            if (tags != null)
            {
                tmptags = JsonConvert.SerializeObject(tags, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });
            }
            //todo [Az] add tags =>  ("tags", tmptags)

            var response = await _httpService.Post<RunResponse>(_getPath(MLFlowAPI.Runs.BasePath, MLFlowAPI.Runs.Create),


                _getParameters(
                    ("experiment_id", experiment_id.ToString()),
                    ("user_id", user_id),
                    ("run_name", run_name),
                    ("source_type", source_type.ToString()),
                    ("source_name", source_name),
                    ("entry_point_name", entry_point_name),
                    ("start_time", start_time.ToString()),
                    ("source_version", source_version)
                    ));
            return response;
        }

        string _getPath(string basePart, string method)
        {
            return $"{basePart}/{method}";
        }

        private Dictionary<string, T> _getParameters<T>(params (string name, T value)[] items)
        {
            return items.Where(i =>
                !string.IsNullOrWhiteSpace(i.name)
                && i.value != null)
                .ToDictionary(i => i.name, i => i.value);
        }
    }
}
