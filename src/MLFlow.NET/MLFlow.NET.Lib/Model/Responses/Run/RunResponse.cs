using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Responses.Run
{
    public class RunResponse
    {
        [JsonProperty("run")]
        public Run Run { get; set; }
    }
}
