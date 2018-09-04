using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using Tiny.Http.Tests.Models;

namespace Tiny.Http.ForTest.Api.Controllers
{
    [Route("api/TimeoutTest")]
    [ApiController]
    public class TimeoutController : ControllerBase
    {
        public TimeoutController()
        {
        }

        [HttpGet("Action400ms")]
        public Task Action400ms()
        {
            return Task.Delay(400);
        }
    }
}
