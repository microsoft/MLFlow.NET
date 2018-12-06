using System;
using System.Collections.Generic;
using System.Text;

namespace MLFlow.NET.Lib.Model
{
    public class MLFlowAPI
    {

        public class Experiments
        {
            public const string BasePath = "experiments";
            public const string Create = "create";
        }
        public class Runs
        {
            public const string BasePath = "runs";
            public const string Create = "create";
            public const string LogMetric = "log-metric";
            public const string LogParam = "log-parameter";
        }

       
    }
}
