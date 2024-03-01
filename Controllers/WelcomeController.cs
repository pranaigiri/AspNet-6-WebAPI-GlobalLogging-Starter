using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Log.Information("Hi This is Serilog Log from the Controller");
            return Ok("Welcome to the ASP.Net 6.0 Starter Project with Global Logging using SeriLog!");
        }
    }
}