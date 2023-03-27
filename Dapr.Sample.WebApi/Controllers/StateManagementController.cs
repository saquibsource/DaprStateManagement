using Dapr.Sample.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dapr.Sample.WebApi.Controllers
{
    /// <summary>
    /// Sample showing Dapr State management with controller.
    /// </summary>
    [ApiController]
    public class StateManagementController : ControllerBase
    {
        private readonly MyStore _myStore;
        public StateManagementController(MyStore myStore)
        {
            _myStore = myStore;
        }
        [HttpGet("myStore/{key}/{value}")]
        public async Task<IActionResult> Set(string key, string value)
        {
            await _myStore.Set(key, value);
            return Ok();
        }
        [HttpGet("myStore/{key}")]
        public async Task<IActionResult> Get(string key)
        {
            
            var value = await _myStore.Get(key);
            return Ok(value);
        }
    }
}
