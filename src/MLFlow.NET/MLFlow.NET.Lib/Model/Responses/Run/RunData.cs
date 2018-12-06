using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Responses.Run
{
    public class RunData
    {
        [JsonProperty("metrics")]
        public Metric[] Metrics { get; set; }

        [JsonProperty("params")]
        public Param[] Params { get; set; }

        [JsonProperty("tags")]
        public RunTag[] Tags { get; set; }
    }

    public class Metric
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("value")]
        public float Value { get; set; }
        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

    
    }

    public class Param
    {

    }

    public class RunTag
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}