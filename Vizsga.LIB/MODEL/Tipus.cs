using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsga.LIB.MODEL
{
    public class Tipus
    {
        [Key]
        public int TipusId { get; set; }
        public string? TipusNev { get; set; } = string.Empty;
    }
}
