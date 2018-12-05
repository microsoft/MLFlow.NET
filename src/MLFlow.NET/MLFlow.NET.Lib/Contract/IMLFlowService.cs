using System.Threading.Tasks;
using MLFlow.NET.Lib.Model.Responses.Experiment;

namespace MLFlow.NET.Lib.Contract
{
    public interface IMLFlowService
    {
        Task<CreateResponse> CreateExperiment(string name,
            string artifact_location = null);
    }
}