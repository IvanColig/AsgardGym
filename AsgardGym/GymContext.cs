using AsgardGym.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace AsgardGym
{
    public class GymContext : DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Posjeta> Posjete { get; set; }
        public DbSet<Usluga> Usluge { get; set; }
        public DbSet<UslugaKorisnika> UslugeKorisnika { get; set; }
        public DbSet<Admin> Admini { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=gyms.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UslugaKorisnika>()
                .HasKey(uk => new { uk.KorisnikID, uk.UslugaID});

            modelBuilder.Entity<Admin>()
            .HasIndex(a => a.KorisnickoIme)
            .IsUnique();
        }


    }
}

