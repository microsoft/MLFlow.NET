using System.Collections.Generic;
using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Responses.Experiment
{
    public class GetExperimentResponse
    {
        [JsonProperty("experiment")]
        public Experiment Experiment { get; set; }

        [JsonProperty("runs")]
        public List<ExperimentRun> Runs { get; set; }
    }
}
