using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsga.LIB.MODEL
{
    public class Kategoria
    {
        [Key]
        public int KategoriaId { get; set; }
        public string KategoriaNev { get; set; } = String.Empty;
    }
}
