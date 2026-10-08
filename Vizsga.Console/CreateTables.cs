using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vizsga.LIB.CLIENT;
using Vizsga.LIB.MODEL;
using System.Net.Http.Json;

namespace Vizsga.Console
{
    internal class CreateTables
    {
        private static readonly VizsgaApiClient apiClient = new();

        internal static async Task<bool> DatabaseCreatedAsync()
        {
            return await apiClient.Client.GetFromJsonAsync<bool>("api/Database/created");
        }


        /**** Ha az API lassan indulna ****
         * internal static async Task<bool> DatabaseCreatedAsync()
{
     while (true)
    {
        try
        {
            return await apiClient.Client.GetFromJsonAsync<bool>("api/Database/created");
        }
        catch (HttpRequestException)
        {
            Console.WriteLine("Várakozás az API indulására...");
            await Task.Delay(500);
        }
    }
}
         */


        internal static async Task CreateTipusAsync(List<Tipus> tipusok)
        {
            foreach (var tipus in tipusok)
            {
                await apiClient.Client.PostAsJsonAsync("api/Tipus", tipus);
            }
        }

        internal static async Task CreateKategoriaAsync(List<Kategoria> kategoriak)
        {
            foreach (var item in kategoriak)
            {
                await apiClient.Client.PostAsJsonAsync("api/Kategoria", item);
            }
        }

        internal static async Task CreateFilmAsync(List<Film> filmek)
        {
            foreach (var item in filmek)
            {
                await apiClient.Client.PostAsJsonAsync("api/Film", item);
            }
        }

        internal static async Task CreateFilmTipusAsync(List<FilmTipus> filmTipusok)
        {
            foreach (var item in filmTipusok)
            {
                await apiClient.Client.PostAsJsonAsync("api/FilmTipus", item);
            }
        }

        internal static async Task CreateVetitesiIdoAsync(List<VetitesiIdo> vetitesiIdok)
        {
            foreach (var item in vetitesiIdok)
            {
                await apiClient.Client.PostAsJsonAsync("api/FilmVetitesIdo", vetitesiIdok);
            }

        }
    }
}
