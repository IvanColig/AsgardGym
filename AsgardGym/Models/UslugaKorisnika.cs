using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsgardGym.Models
{
    public class UslugaKorisnika
    {
        public int KorisnikID { get; set; }
        public int UslugaID { get; set; }
        public DateTime DatumKoristenja { get; set; }

        [ForeignKey("KorisnikID")]
        public Korisnik Korisnik { get; set; }

        [ForeignKey("UslugaID")]
        public Usluga Usluga { get; set; }
    }
}
