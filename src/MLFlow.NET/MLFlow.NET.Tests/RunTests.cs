using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LibGit2Sharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLFlow.NET.Lib.Contract;
using MLFlow.NET.Lib.Model;
using MLFlow.NET.Lib.Model.Responses.Experiment;
using MLFlow.NET.Lib.Model.Responses.Run;
using Newtonsoft.Json;

namespace MLFlow.NET.Tests
{
    [TestClass]
    public class RunTests : TestBase
    {
        [TestMethod]
        public void JsonNetConversionShouldWork()
        {
            var responseBody = @"{
                  ""run"": {
                    ""info"": {
                      ""run_uuid"": ""4b6561093eed4107a565a55b41f5b2f2"",
                      ""experiment_id"": ""11"",
                      ""name"": """",
                      ""source_type"": ""NOTEBOOK"",
                      ""source_name"": ""String descriptor for the run\u2019s source"",
                      ""user_id"": ""azadeh khojandi"",
                      ""status"": ""RUNNING"",
                      ""start_time"": ""1543990082"",
                      ""source_version"": ""95fddd654d1b3b2a6ff8d7417b4627afd42e51df"",
                      ""entry_point_name"": ""Name of the project entry point associated with the current run, if any."",
                      ""artifact_uri"": ""wasbs://mlflowcontainer@mlflowruns.blob.core.windows.net/11/4b6561093eed4107a565a55b41f5b2f2/artifacts"",
                      ""lifecycle_stage"": ""active""
                    }
                  }
                }";
            var result = JsonConvert.DeserializeObject<RunResponse>(responseBody);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Run);
            Assert.IsNotNull(result.Run.Info);
            Assert.AreEqual(result.Run.Info.RunUuid, "4b6561093eed4107a565a55b41f5b2f2");
        }
        [TestMethod]
        public async Task TestCreateRun()
        {

            var flowService = Resolve<IMLFlowService>();
            var g = Guid.NewGuid().ToString();
            var result = await flowService.CreateExperiment(g);
            Assert.IsNotNull(result);

            var runResult = await _createRun(result.ExperimentId, flowService);

            Assert.IsNotNull(runResult);
        }

        public async Task<CreateResponse> _createExperiment(string id, IMLFlowService flowService)
        {
            var result = await flowService.CreateExperiment(id);

            return result;
        }

        public async Task<RunResponse> _createRun(int experiementId, IMLFlowService flowService)
        {
            var experimentId = experiementId;
            var userId = "azadeh khojandi";
            var runName = "this is a run name";
            var sourceType = SourceType.NOTEBOOK;
            var sourceName = "String descriptor for the run’s source";

            var entryPointName = "Name of the project entry point associated with the current run, if any.";
            var startTime = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds(); //unix timestamp


            var path = Directory.GetCurrentDirectory();
            var repopath = path.Substring(0, path.IndexOf("src", StringComparison.Ordinal));
            var repo = new Repository(repopath);
            var lastcommit = repo.Commits.Last();
            var sourceVersion = lastcommit.Sha;


            RunTag[] tags = { new RunTag() { Key = "testkey", Value = "testvalue" } };

            //todo [az] run name is empty - check mlflow source code
            //todo [az] unix startTime not showing correct time on the UI

            var createRunRequest = new CreateRunRequest()
            {
                ExperimentId = experimentId,
                UserId = userId,
                Runname = runName,
                SourceType = sourceType,
                SourceName = sourceName,
                EntryPointName = entryPointName,
                StartTime = startTime,
                SourceVersion = sourceVersion,
                Tags = tags
            };

            var runResult = await flowService.CreateRun(
                createRunRequest);

            return runResult;
        }

        [TestMethod]
        public async Task TestLogMetric()
        {

            var flowService = Resolve<IMLFlowService>();
            var g = Guid.NewGuid().ToString();
            var result = await _createExperiment(g, flowService);
            Assert.IsNotNull(result);

            var runResult = await _createRun(result.ExperimentId, flowService);

            Assert.IsNotNull(runResult);

            var logResult = await flowService
                .LogMetric(
                    runResult.Run.Info.RunUuid,
                    "Somekey", 1234);

            Assert.IsNotNull(logResult);
        }

        [TestMethod]
        public async Task TestLogParam()
        {

            var flowService = Resolve<IMLFlowService>();
            var g = Guid.NewGuid().ToString();
            var result = await _createExperiment(g, flowService);
            Assert.IsNotNull(result);

            var runResult = await _createRun(result.ExperimentId, flowService);

            Assert.IsNotNull(runResult);

            var logResult = await flowService
                .LogParameter(
                    runResult.Run.Info.RunUuid,
                    "Somekey", "some parameter");

            Assert.IsNotNull(logResult);
        }
    }
}
