using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LibGit2Sharp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MLFlow.NET.Lib;
using MLFlow.NET.Lib.Contract;
using MLFlow.NET.Lib.Model;
using MLFlow.NET.Lib.Model.Responses.Experiment;
using MLFlow.NET.Lib.Model.Responses.Run;

namespace MLFlow.Sample.CLI
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var services = _bootApp();

            var flowService = services.GetService<IMLFlowService>();


            var g = Guid.NewGuid().ToString();
            var result = await _createExperiment(g, flowService);

            Console.WriteLine($"Added new experiement with ID:{result.ExperimentId}");

            var runResult = await _createRun(result.ExperimentId, flowService);

            Console.WriteLine($"Added new run with run id:{runResult.Run.Info.RunUuid}");

            var logResultMetric = await flowService
                .LogMetric(
                    runResult.Run.Info.RunUuid,
                    "Somekey", 1234);

            var logResultParam = await flowService
                .LogParameter(
                    runResult.Run.Info.RunUuid,
                    "Somekey", "some parameter");

            Console.WriteLine("Logged results. Finished. ");
        }

        static async Task<CreateResponse> _createExperiment(string id, IMLFlowService flowService)
        {
            var result = await flowService.CreateExperiment(id);

            return result;
        }

        static async Task<RunResponse> _createRun(int experiementId, IMLFlowService flowService)
        {
            var experimentId = experiementId;
            var userId = "azadeh khojandi";
            var runName = "this is a run name";
            var sourceType = SourceType.NOTEBOOK;
            var sourceName = "String descriptor for the run’s source";
            var entryPointName = "Name of the project entry point associated with the current run, if any.";
            var startTime = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds(); //unix timestamp
           
            //get source version
            var path = Directory.GetCurrentDirectory();
            var repopath = path.Substring(0, path.IndexOf("src", StringComparison.Ordinal));
            var repo = new Repository(repopath);
            var lastcommit = repo.Commits.Last();
            var sourceVersion = lastcommit.Sha;


            RunTag[] tags = { new RunTag() { Key = "testkey", Value = "testvalue" } };

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

            var runResult = await flowService.CreateRun(createRunRequest);
            return runResult;
        }

        static IServiceProvider _bootApp()
        {
            var builder = new ConfigurationBuilder();
            // tell the builder to look for the appsettings.json file
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddMFlowNet();

            serviceCollection.Configure<MLFlowConfiguration>(
                configuration.GetSection(nameof(MLFlowConfiguration)
                ));

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
