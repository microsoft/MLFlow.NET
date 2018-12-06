using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Responses.Experiment
{
    public class ExperimentRun
    {
        [JsonProperty("run_uuid")]
        public string RunUuid { get; set; }
        [JsonProperty("experiment_id")]
        public string ExperimentId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("source_type")]
        public string SourceType { get; set; }
        [JsonProperty("source_name")]
        public string SourceName { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("start_time")]
        public string StartTime { get; set; }
        [JsonProperty("artifact_uri")]
        public string ArtifactUri { get; set; }
        [JsonProperty("lifecycle_stage")]
        public string LifecycleStage { get; set; }
        [JsonProperty("source_version")]
        public string SourceVersion { get; set; }
        [JsonProperty("entry_point_name")]
        public string EntryPointName { get; set; }
    }
}