using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vizsga.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        [HttpGet("created")]
        public ActionResult<bool> Created()
        {
            return Ok(Program.DatabaseCreated);
        }
    }
}
