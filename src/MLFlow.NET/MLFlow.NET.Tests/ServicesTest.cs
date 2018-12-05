using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLFlow.NET.Lib.Contract;

namespace MLFlow.NET.Tests
{
    [TestClass]
    public class ServicesTest : TestBase
    {
        [TestMethod]
        public void TestResolveThings()
        {
            var flowService = Resolve<IMLFlowService>();

            Assert.IsNotNull(flowService);
        }
    }
}
