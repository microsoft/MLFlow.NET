using MLFlow.NET.Lib.Contract;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MLFlow.NET.Lib.Model.Responses.Run
{
    public class CreateRunRequest
    {
        [JsonProperty("experiment_id")]
        public int ExperimentId { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("runname")]
        public string Runname { get; set; }
        [JsonProperty("source_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SourceType SourceType { get; set; }
        [JsonProperty("source_name")]
        public string SourceName { get; set; }
        [JsonProperty("entry_point_name")]
        public string EntryPointName { get; set; }
        [JsonProperty("start_time")]
        public long StartTime { get; set; }
        [JsonProperty("source_version")]
        public string SourceVersion { get; set; }
        [JsonProperty("tags")]
        public RunTag[] Tags { get; set; }
    }
}
