using Microsoft.AspNetCore.Mvc;

namespace PosApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            return Ok(new[] { "value1", "value2" });
        }
    }
}