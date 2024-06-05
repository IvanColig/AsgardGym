using System.ComponentModel.DataAnnotations;

namespace AsgardGym.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
    }
}
