using Microsoft.AspNetCore.Mvc;

namespace Acme.Webhooks.Controllers
{
    /// <summary>
    /// The Webhooks service may contain other non-webhook-related APIs. 
    /// This controller demonstrates adding "standard" API endpoints to your project.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult Status()
        {
            return Ok("All systems are go!");
        }

    }
}
