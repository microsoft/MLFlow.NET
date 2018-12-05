using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Responses.Run
{
    public class Run
    {
        [JsonProperty("info")]
        public RunInfo Info { get; set; }

        [JsonProperty("data")]
        public RunData Data { get; set; }


    }
}