using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Responses.Experiment
{
    public class CreateResponse
    {
        [JsonProperty("experiment_id")]
        public int ExperimentId { get; set; }
    }
}
