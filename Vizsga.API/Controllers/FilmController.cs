using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vizsga.API.Data;
using Vizsga.LIB.MODEL;

namespace Vizsga.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly VizsgaDbContext dbContext;

        public FilmController(VizsgaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Film>> Post(Film Film)
        {
            Film.FilmId = 0; // Ensure the ID is set to 0 for a new entity
            dbContext.Film.Add(Film);
            await dbContext.SaveChangesAsync();

            return Created("", Film);
        }
    }
}
