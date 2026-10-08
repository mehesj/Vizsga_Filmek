using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsga.LIB.MODEL
{
    public class FilmTipus
    {
        [Key]
        public int FilmTipusId { get; set; }
        public int FilmId { get; set; }
        public int TipusId { get; set; }
    }
}
