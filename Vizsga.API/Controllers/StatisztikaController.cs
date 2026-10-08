using global::Vizsga.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vizsga.LIB.ViewModel;

namespace Vizsga.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisztikaController : ControllerBase
    {
        private readonly VizsgaDbContext dbContext;

        public StatisztikaController(VizsgaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("film-count")]
        public async Task<ActionResult<int>> GetFilmCountAsync()
        {
            int filmCount = await dbContext.Film.CountAsync();

            return Ok(filmCount);
        }

        [HttpGet("long-film-count")]
        public async Task<ActionResult<LongFilmCountViewModel>> GetLongFilmCountAsync()
        {

            int twoDId = await dbContext.Kategoria
            .Where(k => k.KategoriaNev == "2D")
            .Select(k => k.KategoriaId)
            .FirstAsync();

            int threeDId = await dbContext.Kategoria
            .Where(k => k.KategoriaNev == "3D")
            .Select(k => k.KategoriaId)
            .FirstAsync();

            int twoDCount = await dbContext.Film
                .CountAsync(f => f.Hossz > 100 && f.KategoriaId == twoDId);

            int threeDCount = await dbContext.Film
                .CountAsync(f => f.Hossz > 100 && f.KategoriaId == threeDId);

            LongFilmCountViewModel result = new()
            {
                TwoDCount = twoDCount,
                ThreeDCount = threeDCount
            };

            return Ok(result);
        }
    }
}

