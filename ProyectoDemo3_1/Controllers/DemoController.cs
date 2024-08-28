using Microsoft.AspNetCore.Mvc;

namespace ProyectoDemo3_1.Controllers
{

    [ApiController]
    [Route("api/[action]")]
    public class DemoController : Controller
    {
        [HttpGet]
        public IActionResult Health()
        {
            return Ok("Service is running");
        }
    }
}
