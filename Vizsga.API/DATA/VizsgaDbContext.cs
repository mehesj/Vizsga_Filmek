using Microsoft.EntityFrameworkCore;
using Vizsga.LIB.MODEL;

namespace Vizsga.API.Data
{
    public class VizsgaDbContext : DbContext
    {
        //          C# obj  Táblaneve
        public DbSet<Film> Film { get; set; }
        public DbSet<Tipus> Tipus { get; set; }
        public DbSet<FilmTipus> FilmTipus { get; set; }
        public DbSet<Kategoria> Kategoria { get; set; }
        public DbSet<VetitesiIdo> VetitesiIdo { get; set; }


        // Mikor hívódik meg, ha példányosítunk???
        public VizsgaDbContext(DbContextOptions<VizsgaDbContext> options) : base(options)
        {
        }
    }
}