using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLFlow.NET.Lib.Contract;
using MLFlow.NET.Lib.Model.Responses.Run;

namespace MLFlow.NET.Tests
{
    [TestClass]
    public class LogTests : TestBase
    {
        [TestMethod]
        public async Task TestLogMetric()
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

            var logResult = await flowService
                .LogMetric(
                    runResult.Run.Info.RunUuid,
                    "Somekey", 1234);

            Assert.IsNotNull(logResult);
        }
    }
}
