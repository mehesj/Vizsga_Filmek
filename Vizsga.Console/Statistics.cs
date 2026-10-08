using System.Net.Http.Json;
using Vizsga.LIB;
using Vizsga.LIB.CLIENT;
using Vizsga.LIB.ViewModel;

namespace Vizsga.ConsoleApp
{
    internal static class Statistics
    {
        private static readonly VizsgaApiClient apiClient = new();

        internal static async Task Task2FilmCountAsync()
        {
            int filmCount = await apiClient.Client.GetFromJsonAsync<int>("api/Statisztika/film-count");

            System.Console.WriteLine("2. feladat");
            System.Console.WriteLine($"Összesen {filmCount} film adata szerepel az állományban.");
            System.Console.WriteLine();
        }

        internal static async Task Task3LongFilmCountAsync()
        {
            LongFilmCountViewModel? result = await apiClient.Client.GetFromJsonAsync<LongFilmCountViewModel>("api/Statisztika/long-film-count");

            System.Console.WriteLine("3. feladat");
            System.Console.WriteLine($"\t2D-s filmek: {result!.TwoDCount} db");
            System.Console.WriteLine($"\t3D-s filmek: {result.ThreeDCount} db");
            System.Console.WriteLine();
        }
    }
}