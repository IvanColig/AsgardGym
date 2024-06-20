using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsgardGym.Models
{
    public class Posjeta
    {
        [Key]
        public int PosjetaID { get; set; }
        public int KorisnikID { get; set; }
        public int UslugaID { get; set; }
        public DateTime DatumPosjete { get; set; }

        [ForeignKey("KorisnikID")]
        public Korisnik Korisnik { get; set; }

        [ForeignKey("UslugaID")]
        public Usluga Usluga { get; set; }
    }
}
