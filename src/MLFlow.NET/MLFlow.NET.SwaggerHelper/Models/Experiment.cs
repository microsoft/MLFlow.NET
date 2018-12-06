using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLFlow.NET.SwaggerHelper.Models
{
    public class Experiment
    {
        public int experiment_id { get; set; }
        public string name { get; set; }
        public string artifact_location { get; set; }
        public string lifecycle_stage { get; set; }
        public int last_update_time { get; set; }
        public int creation_time { get; set; }

    }
}
