using System.Collections.Generic;
using System.Threading.Tasks;

namespace MLFlow.NET.Lib.Contract
{
    public interface IHttpService
    {
        Task<T> Post<T>(string urlPart, Dictionary<string, string> parameters)
            where T : class;
    }
}