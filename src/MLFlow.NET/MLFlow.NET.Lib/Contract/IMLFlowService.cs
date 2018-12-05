using System.Threading.Tasks;

namespace MLFlow.NET.Lib.Contract
{
    public interface IMLFlowService
    {
        Task<int> CreateExperiment(
            string name, 
            string artifact_location = null);
    }
}