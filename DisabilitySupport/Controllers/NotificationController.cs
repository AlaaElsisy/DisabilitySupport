using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisabilitySupport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetNotifications()
        {
           
            return Ok();
        }
    }
}
