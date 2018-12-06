using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MLFlow.NET.SwaggerHelper.Controllers
{
    [Route("2.0/preview/mlflow/runs")]
    public class RunsController
    {
        [Route("create")]
        [HttpPost]
        public IActionResult create(
            [Required]string name, 
            string artifact_location = null)
        {
            return null;
        }
    }
}
