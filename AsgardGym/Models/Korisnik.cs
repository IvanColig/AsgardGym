using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsgardGym.Models
{
    public class Korisnik
    {
        [Key]
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodenja { get; set; }
        public string Email { get; set; }
        public int Telefon { get; set; }

        public ICollection<Posjeta> Posjete { get; set; }
        public ICollection<UslugaKorisnika> UslugeKorisnika { get; set; }
    }
}
