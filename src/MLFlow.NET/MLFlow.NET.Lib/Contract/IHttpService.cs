using System.Collections.Generic;
using System.Threading.Tasks;

namespace MLFlow.NET.Lib.Contract
{
    public interface IHttpService
    {
        Task<T> Post<T, Y>(string urlPart, Y request)
            where T : class
            where Y : class;
    }
}