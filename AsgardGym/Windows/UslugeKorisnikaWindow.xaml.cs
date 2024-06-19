using System.Linq;
using System.Windows;
using AsgardGym.Models;
using Microsoft.EntityFrameworkCore;

namespace AsgardGym.Windows
{
    public partial class UslugeKorisnikaWindow : Window
    {
        private Korisnik korisnik;
        private GymContext _context;

        public UslugeKorisnikaWindow(Korisnik korisnik)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            _context = new GymContext();

            PrikaziPodatke();
            IzracunajUkupno();
        }

        private void PrikaziPodatke()
        {
            ImePrezimeTextBlock.Text = $"{korisnik.Ime} {korisnik.Prezime}";

            var uslugeKorisnika = _context.UslugeKorisnika
                                        .Include(uk => uk.Usluga)
                                        .Where(uk => uk.KorisnikID == korisnik.KorisnikID)
                                        .Select(uk => uk.Usluga)
                                        .ToList();

            UslugeListBox.ItemsSource = uslugeKorisnika;
        }

        private void IzracunajUkupno()
        {
            double ukupno = _context.UslugeKorisnika
                                .Include(uk => uk.Usluga)
                                .Where(uk => uk.KorisnikID == korisnik.KorisnikID)
                                .Sum(uk => uk.Usluga.Cijena);

            UkupnoTextBlock.Text = $"{ukupno} €";
        }

        private void DodajUslugu_Click(object sender, RoutedEventArgs e)
        {
            var dodajUsluguKorisnikaWindow = new DodajUsluguKorisnikaWindow(korisnik);

            if (dodajUsluguKorisnikaWindow.ShowDialog() == true)
            {
                PrikaziPodatke();
                IzracunajUkupno();
            }
        }

        private void UkloniUslugu_Click(object sender, RoutedEventArgs e)
        {
            if (UslugeListBox.SelectedItem is Usluga odabranaUsluga)
            {
                MessageBoxResult result = MessageBox.Show("Ukloniti odabranu uslugu?", "Ukloni uslugu", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    var uslugaKorisnika = _context.UslugeKorisnika.FirstOrDefault(uk => uk.KorisnikID == korisnik.KorisnikID && uk.UslugaID == odabranaUsluga.UslugaID);
                    if (uslugaKorisnika != null)
                    {
                        _context.UslugeKorisnika.Remove(uslugaKorisnika);
                        _context.SaveChanges();
                        PrikaziPodatke();
                    }
                }
            }
            else
            {
                MessageBox.Show("Odaberite uslugu koju želite ukloniti.");
            }
        }


        private void Natrag_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
