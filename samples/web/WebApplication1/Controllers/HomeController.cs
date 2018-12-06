using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLFlow.NET.Lib.Contract;
using MLFlow.NET.Lib.Model.Responses.Run;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMLFlowService flowService;

        public HomeController(IMLFlowService flowService)
        {
            this.flowService = flowService;
        }
        public async Task<IActionResult> Index()
        {
            var newExperiment = await this.flowService.CreateExperiment("New_Experiement");

            var experimentId = newExperiment.ExperimentId;
            var userId = "azadeh khojandi";
            var runName = "this is a run name";
            var sourceType = SourceType.NOTEBOOK;
            var sourceName = "String descriptor for the run’s source";

            var entryPointName = "Name of the project entry point associated with the current run, if any.";
            var startTime = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds(); //unix timestamp


          

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
                "",
                tags);

            var logResultMetric = await flowService
                .LogMetric(
                    runResult.Run.Info.RunUuid,
                    "Somekey", 1234);

            var logResultParam = await flowService
                .LogParameter(
                    runResult.Run.Info.RunUuid,
                    "Somekey", "some parameter");

            ViewData["ExperimentId"] = experimentId;
            ViewData["RunId"] = runResult.Run.Info.RunUuid;

            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
