using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsga.LIB.MODEL
{
    public class Film
    {
        [Key]
        public int FilmId { get; set; }
        public string Cim { get; set; } = string.Empty;
        public int KategoriaId { get; set; }
        public int Hossz { get; set; }
        public DateOnly KezdoDatum { get; set; }

    }
}
