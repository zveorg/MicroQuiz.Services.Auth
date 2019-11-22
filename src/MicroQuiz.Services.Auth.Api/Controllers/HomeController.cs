using Microsoft.AspNetCore.Mvc;

namespace MicroQuiz.Services.Auth.Api.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("MicroQuiz Identity Service");
    }
}