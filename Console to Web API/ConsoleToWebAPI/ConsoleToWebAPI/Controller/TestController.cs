using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controller
{
    [ApiController]
    [Route("test/[action]")]
    public class TestController : ControllerBase
    {
        public string Get()
        {
            return "Hello! I am Controller Class.";
        }

        public string Get1()
        {
            return "Hello! I am Controller Class 2nd method.";
        }
    }
}