using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLFlow.NET.Lib.Contract;
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

            var experimentId = result.ExperimentId;
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

            //todo [az] pass tags
            //RunTag[] tags = new RunTag[]{new RunTag(){Key = "testkey",Value = "testvalue"} };

            //todo [az] runame is empty - check mlflow source code
            
            RunTag[] tags = null;
            var runResult = await flowService.CreateRun(
                experimentId,
                userId,
                runName,
                sourceType,
                sourceName,
                entryPointName,
                startTime,
                sourceVersion,
                tags);

            Assert.IsNotNull(runResult);
        }
    }
}
