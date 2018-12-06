using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MLFlow.NET.Lib.Contract;
using MLFlow.NET.Lib.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace MLFlow.NET.Lib.Services
{
    public class HttpService : IHttpService
    {
        private readonly IOptions<MLFlowConfiguration> _config;
        private HttpClient _client;
        public HttpService(IOptions<MLFlowConfiguration> config)
        {
            _config = config;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(config.Value.MlFlowServerBaseUrl);
        }

        string _serialise<T>(Dictionary<string, T> parameters)
        {
            
            
            var content =  JsonConvert.SerializeObject(parameters, Newtonsoft.Json.Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            return content;
        }

        public async Task<T> Post<T>(string urlPart, Dictionary<string, string> parameters)
            where T:class 
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions
            try
            {

                var uri = _getUrl(urlPart);
                var content = new StringContent(_serialise(parameters));
                var response = await _client.PostAsync(uri, content);

                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(responseBody);
                return result;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return null;
        }

        private Uri _getUrl(string urlPart)
        {
            var baseUri = new Uri(new Uri(_config.Value.MlFlowServerBaseUrl), _config.Value.APIBase);
            var fullUri = new Uri(baseUri, urlPart);
            return fullUri;
        }
    }
}
