// See https://aka.ms/new-console-template for more information
using Vizsga.Console;
using Vizsga.LIB.MODEL;


Console.BackgroundColor = ConsoleColor.DarkBlue;
Console.Clear();
Console.ForegroundColor = ConsoleColor.White;
Console.Title = "Vizsga - Adatok beolvasása CSV fájlból";

bool isDatabaseCreated = await CreateTables.DatabaseCreatedAsync();


if (isDatabaseCreated) // Ha az adatbázis az indítással jött létre, akkor feltöltjük.
{
    Console.WriteLine("Adatok beolvasása az adatfájlból:");

    /*** 1. Adatfájl beolvasása List<string[]>-be ***/
    // Az adatfájl beolvasása a ManageFile osztály ReadFromCsv metódusával
    //List<string[]>
    var data = ManageFile.ReadFromCsv("adatok.txt", '\t', true);/*** Adatfájl beolvasása ***/



    foreach (string[] row in data)
    {
        Console.WriteLine(string.Join(", ", row));
    }

    /*** 2. A beolvasott adatok C# objektumba töltése ***/
    List<Kategoria> kategoriak = GenerateDTO.GenerateKategoria(data);
    List<Tipus> tipusok = GenerateDTO.GenerateTipus(data);
    List<Film> filmek = GenerateDTO.GenerateFilm(data, kategoriak, tipusok);
    List<FilmTipus> filmTipusok = GenerateDTO.GenerateFilmTipus(data, filmek, tipusok);
    List<VetitesiIdo> vetitesiIdok = GenerateDTO.GenerateVetitesiIdo(data, filmek);

    /*** 3. Adatbázisba írás ***/
    Console.WriteLine($"Típusok száma: {tipusok.Count}");
    await CreateTables.CreateTipusAsync(tipusok);

    Console.WriteLine($"Kategóriák száma: {kategoriak.Count}");
    await CreateTables.CreateKategoriaAsync(kategoriak);

    Console.WriteLine($"Filmek száma: {filmek.Count}");
    await CreateTables.CreateFilmAsync(filmek);

    Console.WriteLine($"FilTípusok száma: {filmTipusok.Count}");
    await CreateTables.CreateFilmTipusAsync(filmTipusok);

    Console.WriteLine($"Vetítési idők száma: {vetitesiIdok.Count}");
    await CreateTables.CreateVetitesiIdoAsync(vetitesiIdok);

    Console.WriteLine("Adatbetöltés OK");
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Adatbázis már létezik, az adatbetöltés nem történt meg.");
    Console.WriteLine();
}

Console.ReadKey();

/*** 4. Adatbázis ellenőrzés ***/
/*
1. Partial class Program -> DatabaseCreated property
2. Program.cs -> DatabaseCreated = context.Database.EnsureCreated();
3. DatabaseController.cs -> [HttpGet("created")] public ActionResult<bool> IsDatabaseCreated() { return Program.DatabaseCreated; }
4. CreateTables.cs -> DatabaseCreatedAsync() -> await apiClient.Client.GetFromJsonAsync<bool>("api/Database/created");
5. Program.cs -> await CreateTables.DatabaseCreatedAsync() -> if (!isDatabaseCreated) { Console.WriteLine("Adatbázis nem jött létre!"); return; }
 */
