using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vizsga.API.Data;
using Vizsga.LIB.MODEL;

namespace Vizsga.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmTipusController : ControllerBase
    {
        private readonly VizsgaDbContext dbContext;

        public FilmTipusController(VizsgaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<FilmTipus>> Post(FilmTipus FilmTipus)
        {
            FilmTipus.FilmTipusId = 0; // Ensure the ID is set to 0 for a new entity
            dbContext.FilmTipus.Add(FilmTipus);
            await dbContext.SaveChangesAsync();

            return Created("", FilmTipus);
        }
    }
}
