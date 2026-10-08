// See https://aka.ms/new-console-template for more information
using Vizsga.Console;
using Vizsga.LIB.MODEL;


Console.BackgroundColor = ConsoleColor.DarkBlue;
Console.Clear();
Console.ForegroundColor = ConsoleColor.White;
Console.Title = "Vizsga - Adatok beolvasása CSV fájlból";

Console.WriteLine("Adatok beolvasása az adatfájlból:");

/*** 1. Adatfájl beolvasása List<string[]>-be ***/
// Az adatfájl beolvasása a ManageFile osztály ReadFromCsv metódusával
//List<string[]>
var data = ManageFile.ReadFromCsv("adatok.txt", '\t', true);



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
Console.ReadKey();
