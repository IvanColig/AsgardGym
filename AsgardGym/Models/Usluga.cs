using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsgardGym.Models
{
    public class Usluga
    {
        [Key]
        public int UslugaID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public int Cijena { get; set; }

        public ICollection<UslugaKorisnika> UslugeKorisnika { get; set; }
    }
}
