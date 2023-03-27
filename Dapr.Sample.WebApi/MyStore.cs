
using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace Dapr.Sample.WebApi
{
    public class MyStore
    {
        private readonly DaprClient _daprClient;
        public MyStore(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }
        [HttpPost("myStore/{key}")]
        public async Task Set(string key, [FromBody] string value)
        {
            await _daprClient.SaveStateAsync("mystore", key, value);
        }
        [HttpGet("myStore/{key}")]
        public async Task<string> Get(string key)
        {
            return await _daprClient.GetStateAsync<string>("mystore", key);
        }
    }
}
