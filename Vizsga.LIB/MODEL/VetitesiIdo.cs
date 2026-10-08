using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsga.LIB.MODEL
{
    public class VetitesiIdo
    {
        [Key]
        public int VetitesiIdoId { get; set; }
        public int FilmId { get; set; }
        public TimeOnly VetitesOraPerc { get; set; }
    }
}
