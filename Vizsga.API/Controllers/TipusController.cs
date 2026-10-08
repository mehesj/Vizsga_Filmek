using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vizsga.API.Data;
using Vizsga.LIB.MODEL;

namespace Vizsga.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipusController : ControllerBase
    {
        private readonly VizsgaDbContext dbContext;

        public TipusController(VizsgaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Tipus>> Post(Tipus tipus)
        {
            tipus.TipusId = 0; // Ensure the ID is set to 0 for a new entity
            dbContext.Tipus.Add(tipus);
            await dbContext.SaveChangesAsync();

            return Created("", tipus);
        }
    }
}
