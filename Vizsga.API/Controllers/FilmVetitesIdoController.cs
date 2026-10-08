using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vizsga.API.Data;
using Vizsga.LIB.MODEL;

namespace Vizsga.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmVetitesIdoController : ControllerBase
    {
        private readonly VizsgaDbContext dbContext;

        public FilmVetitesIdoController(VizsgaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<VetitesiIdo>> Post(VetitesiIdo FilmVetitesIdo)
        {
            FilmVetitesIdo.VetitesiIdoId = 0; // Ensure the ID is set to 0 for a new entity
            dbContext.VetitesiIdo.Add(FilmVetitesIdo);
            await dbContext.SaveChangesAsync();

            return Created("", FilmVetitesIdo);
        }
    }
}
