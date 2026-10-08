using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vizsga.Console.MODEL;
using Vizsga.LIB.MODEL;

namespace Vizsga.Console
{
    internal class GenerateDTO
    {
        /// <summary>
        /// Kategoria objektumok generálása a CSV fájl adatai alapján.
        /// </summary>
        /// <param name="data">.csv adatok</param>
        /// <returns List<Kategoria> Kategoria nevek listája</returns>
        internal static List<Kategoria> GenerateKategoria(List<string[]> data)
        {
            List<Kategoria> kategoriak = new();
            foreach (var item in data)
            {
                string kategoriaNev = item[(int)DataColums.Kategoria];

                if (!kategoriak.Any(k => k.KategoriaNev == kategoriaNev))
                {
                    Kategoria kategoria = new Kategoria
                    {
                        KategoriaId = kategoriak.Count + 1,
                        KategoriaNev = kategoriaNev
                    };
                    kategoriak.Add(kategoria);
                }
            }



            return kategoriak;
        }

        internal static List<Tipus> GenerateTipus(List<string[]> data)
        {
            List<Tipus> tipusok = new();

            foreach (var item in data)
            {
                string tipusNev = item[(int)DataColums.Tipus];
                string[] tipusNevek = tipusNev.Split(',', StringSplitOptions.TrimEntries);

                foreach (string nev in tipusNevek)
                {
                    if (!tipusok.Any(t => t.TipusNev == nev))
                    {
                        Tipus tipus = new Tipus
                        {
                            TipusId = tipusok.Count + 1,
                            TipusNev = nev
                        };

                        tipusok.Add(tipus);
                    }
                }
            }

            return tipusok;
        }

        internal static List<Film> GenerateFilm(List<string[]> data, List<Kategoria> kategoriak, List<Tipus> tipusok)
        {
            List<Film> filmek = new();

            foreach (var item in data)
            {
                string filmNev = item[(int)DataColums.Cim];
                string kategoriaNev = item[(int)DataColums.Kategoria];
                Kategoria kategoria = kategoriak.FirstOrDefault(k => k.KategoriaNev == kategoriaNev);
                
                    Film film = new Film
                    {
                        FilmId = filmek.Count + 1,
                        Cim= filmNev,
                        Hossz = int.Parse(item[(int)DataColums.Hossz]),
                        KategoriaId = kategoria.KategoriaId,
                        KezdoDatum = DateOnly.Parse(item[(int)DataColums.KezdoDatum])
                    };

                    filmek.Add(film);
            }

            return filmek;
        }

        internal static List<FilmTipus> GenerateFilmTipus(List<string[]> data, List<Film> filmek, List<Tipus> tipusok)
        {
            List<FilmTipus> filmTipusok = new();



            foreach (var item in data)
            {
                string filmNev = item[(int)DataColums.Cim];
                string tipusNev = item[(int)DataColums.Tipus];     // Szóközök levágása a típusnevekből
                string[] tipusNevek = tipusNev.Split(',', StringSplitOptions.TrimEntries);
                Film film = filmek.FirstOrDefault(f => f.Cim == filmNev);

                foreach (string nev in tipusNevek)
                {                                                           //Dráma 
                    Tipus tipus = tipusok.FirstOrDefault(t => t.TipusNev == nev);
                    if (film != null && tipus != null)
                    {
                        FilmTipus ft = new FilmTipus
                        {
                            FilmTipusId = filmTipusok.Count + 1,
                            FilmId = film.FilmId,
                            TipusId = tipus.TipusId
                        };
                        filmTipusok.Add(ft);
                    }
                }
            }
            return filmTipusok;
        }

        internal static List<VetitesiIdo> GenerateVetitesiIdo(List<string[]> data, List<Film> filmek)
        {
            List<VetitesiIdo> vetitesiIdok = new();
            foreach (var item in data)
            {
                string filmNev = item[(int)DataColums.Cim];
                Film film = filmek.FirstOrDefault(f => f.Cim == filmNev);

                string vetitesek = item[(int)DataColums.VetitesiIdo];
                string[] idopontok = vetitesek.Split(',', StringSplitOptions.TrimEntries);

                foreach (var itemvetites in idopontok)
                {
                    VetitesiIdo vetitesIdo = new VetitesiIdo {VetitesiIdoId = vetitesiIdok.Count + 1, FilmId = film.FilmId, VetitesOraPerc = TimeOnly.Parse(itemvetites)  };
                    vetitesiIdok.Add(vetitesIdo);
                }

            }

            return vetitesiIdok;
        }

        
    }
}
