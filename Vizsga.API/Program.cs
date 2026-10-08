using Microsoft.EntityFrameworkCore;
using Vizsga.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. DbContext regisztrálása a DI konténerben
builder.Services.AddDbContext<VizsgaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 3. Adatbázis migrációk alkalmazása az alkalmazás indításakor
// Létrehozunk egy scope-ot, mivel nem hívásból történik. 
using (var scope = app.Services.CreateScope()) // Szál a feladat végrehajtásához, a scope biztosítja, hogy a DbContext példány élettartama a scope-hoz legyen kötve.
{
    var context = scope.ServiceProvider.GetRequiredService<VizsgaDbContext>(); // Kapcsolat az adatbázishoz
    DatabaseCreated =context.Database.EnsureCreated(); // CSAK ŐSFELTÖLTÉS ESETÉN, ha már van adatbázis, akkor nem csinál semmit. Ha nincs, akkor létrehozza az adatbázist a modellek alapján.
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/// <summary>
/// A Program osztály a fő belépési pont az alkalmazás számára, és tartalmazza az adatbázis létrehozásának állapotát jelző tulajdonságot.
/// </summary>
public partial class Program
{
    public static bool DatabaseCreated { get; set; }
}
