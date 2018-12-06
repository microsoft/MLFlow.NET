using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Responses.Experiment
{
    public class Experiment
    {
        [JsonProperty("experiment_id")]
        public int ExperimentId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("artifact_location")]
        public string ArtifactLocation{ get; set; }
        [JsonProperty("lifecycle_stage")]
        public string LifecycleStage { get; set; }

        [JsonProperty("last_update_time")]
        public string LastUpdateTime { get; set; }

        [JsonProperty("creation_time")]
        public string CreationTime { get; set; }
        
    }
}
