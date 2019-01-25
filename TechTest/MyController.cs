using Microsoft.AspNetCore.Mvc;

namespace TechTest
{
    public class MyController: Controller
    {

        [Route("hello")]
        [HttpGet]
        public IActionResult HelloWorld()
        {
            return Content("Hello!");
        }
    }
}