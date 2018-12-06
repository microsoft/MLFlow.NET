using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MLFlow.NET.Lib.Model.Responses.Experiment;
using MLFlow.NET.Lib.Model.Responses.Run;

namespace MLFlow.NET.Lib.Contract
{
    public interface IMLFlowService
    {
        Task<CreateResponse> CreateExperiment(string name,
            string artifact_location = null);

        /// <summary>
        /// Create a new run within an experiment. A run is usually a single execution of a machine learning or data ETL pipeline. MLflow uses runs to track Param, Metric, and RunTag associated with a single execution.
        /// </summary>
        /// <param name="experiment_id">ID of the associated experiment.</param>
        /// <param name="user_id">ID of the user executing the run.</param>
        /// <param name="run_name">Human readable name for the run.</param>
        /// <param name="source_type">Originating source for the run.</param>
        /// <param name="source_name">String descriptor for the run’s source. For example, name or description of a notebook, or the URL or path to a project.</param>
        /// <param name="entry_point_name">Name of the project entry point associated with the current run, if any.</param>
        /// <param name="start_time">Unix timestamp of when the run started in milliseconds.</param>
        /// <param name="source_version">Git commit hash of the source code used to create run.</param>
        /// <param name="tags">Additional metadata for run.</param>
        /// <returns></returns>
        Task<RunResponse> CreateRun(
            int experiment_id,
            string user_id,
            string run_name,
            SourceType source_type,
            string source_name,
            string entry_point_name,
            long start_time,
            string source_version,
            RunTag[] tags 
            );

        Task<LogMetric> LogMetric(string run_uuid,
            string key, float value, long? timeStamp = null);
    }
}