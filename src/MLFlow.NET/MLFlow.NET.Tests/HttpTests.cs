using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLFlow.NET.Lib.Contract;

namespace MLFlow.NET.Tests
{
    [TestClass]
    public class HttpTests : TestBase
    {
        [TestMethod]
        public async Task TestServerConnection()
        {
            var flowService = Resolve<IMLFlowService>();
            var g = Guid.NewGuid().ToString();
            var result = await flowService.CreateExperiment(g);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ExperimentId >= 0);
        }
    }
}
