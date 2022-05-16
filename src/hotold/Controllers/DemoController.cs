using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

namespace hotold.Controllers
{
    [ApiController]
    [Route("")]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var pid = Process.GetCurrentProcess().Id;
            return $"Hello World! {pid}";
        }
    }
}
