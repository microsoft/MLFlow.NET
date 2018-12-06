using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLFlow.NET.Lib.Contract;
using MLFlow.NET.Lib.Model;

namespace MLFlow.NET.Tests
{
    [TestClass]
    public class ExperimentsTests : TestBase
    {
        [TestMethod]
        public async Task ListExperimentsShouldReturnResult()
        {
            var flowService = Resolve<IMLFlowService>();
            var viewtype = ViewType.ALL;
            var result = await flowService.ListExperiments(viewtype);

            Assert.IsNotNull(result);
        }
    }
}
