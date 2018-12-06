using System.Collections.Generic;
using MLFlow.NET.Lib.Model.Responses.Experiment;
using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Responses.Experiment
{
    public class ListExperimentsResponse
    {
        [JsonProperty("experiments")]
        public List<Experiment> Experiments { get; set; }
    }
}