using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vizsga.API.Data;
using Vizsga.LIB.MODEL;

namespace Vizsga.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriaController : ControllerBase
    {
        private readonly VizsgaDbContext dbContext;

        public KategoriaController(VizsgaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Kategoria>> Post(Kategoria kategoria)
        {
            kategoria.KategoriaId = 0; // Ensure the ID is set to 0 for a new entity
            dbContext.Kategoria.Add(kategoria);
            await dbContext.SaveChangesAsync();

            return Created("", kategoria);
        }
    }
}
