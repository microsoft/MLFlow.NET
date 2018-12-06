using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLFlow.NET.SwaggerHelper.Models;

namespace MLFlow.NET.SwaggerHelper.Controllers
{
    [Route("2.0/preview/mlflow/experiments")]
    public class ExperimentsController : Controller
    {
        /// <summary>
        /// Create Experiment
        /// </summary>
        /// <remarks>
        /// Create an experiment with a name. Returns the ID of the newly created experiment.
        /// Validates that another experiment with the same name does not already exist and fails if another experiment with the same name already exists.
        /// Throws RESOURCE_ALREADY_EXISTS if a experiment with the given name exists.
        /// </remarks>
        /// <param name="name">Experiment name. This field is required.</param>
        /// <param name="artifact_location">Location where all artifacts for the experiment are stored. If not provided, the remote server will select an appropriate default.</param>
        /// <returns></returns>
        [Route("create")]
        [HttpPost]
        public IActionResult create([Required]string name, string artifact_location = null)
        {
            return null;
        }

        /// <summary>
        /// List Experiments
        /// </summary>
        /// <remarks>
        /// Get a list of all experiments.
        /// </remarks>
        /// <param name="view_type">
        ///     Qualifier for type of experiments to be returned. If unspecified, return only active experiments.
        ///     Name	        Description
        ///     ACTIVE_ONLY     Default.Return only active experiments.
        ///     DELETED_ONLY    Return only deleted experiments.
        ///     ALL             Get all experiments.
        /// </param>

        /// <returns></returns>
        [Route("list")]
        [HttpPost]
        public ActionResult<Experiment> list(string view_type)
        {
            return null;
        }
    }
}