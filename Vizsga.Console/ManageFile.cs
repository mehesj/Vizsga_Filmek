using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsga.Console
{
    internal class ManageFile
    {
        /// <summary>
        /// Adatok beolvasása CSV fájlból
        /// </summary>
        /// <param name="fileName">Az adatfájl neve</param>
        /// <param name="separator">A mezők elválasztó karaktere</param>
        /// <param name="hasHeader">Megadja, hogy van-e fejléc a fájlban</param>
        /// <returns List<string[]>Az adatfájl sorainak listája</returns>
        public static List<string[]> ReadFromCsv(string fileName, char separator, bool hasHeader)
        {
            List<string[]> data = new();
            using (StreamReader streamReader = new StreamReader(fileName, Encoding.UTF8))
            {
                // Ha van fejléc, akkor az első sort átugorjuk
                if (hasHeader)
                {
                    streamReader.ReadLine(); // Beolvas egy sort, de nem tesz vele semmit, így az első sor átugrásra kerül
                }

                // Adatok beolvasása
                while (!streamReader.EndOfStream)
                {
                    //             Beolvassa a sort, majd a Split metódussal feldarabolja a mezőket a megadott elválasztó karakter alapján
                    //             A StringSplitOptions.None paraméter azt jelenti, hogy a Split metódus nem hagy ki üres mezőket
                    string[] row = streamReader.ReadLine().Split(separator, StringSplitOptions.None);
                    data.Add(row);
                }
            }




            return data;
        }
    }
}
