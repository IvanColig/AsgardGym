using AsgardGym.Models;
using System.Windows;

namespace AsgardGym.Windows
{
    public partial class DodajUsluguKorisnikaWindow : Window
    {
        private GymContext _context;
        private Korisnik _korisnik;
        public DodajUsluguKorisnikaWindow(Korisnik korisnik)
        {
            InitializeComponent();
            _context = new GymContext();
            _korisnik = korisnik;
            LoadData();
        }
        private void LoadData()
        {
            var uslugeKorisnika = _context.UslugeKorisnika
                                        .Where(uk => uk.KorisnikID == _korisnik.KorisnikID)
                                        .Select(uk => uk.UslugaID)
                                        .ToList();

            var dostupneUsluge = _context.Usluge
                                         .Where(u => !uslugeKorisnika.Contains(u.UslugaID))
                                         .ToList();

            UslugeComboBox.ItemsSource = dostupneUsluge;
            UslugeComboBox.DisplayMemberPath = "Naziv";
            UslugeComboBox.SelectedValuePath = "UslugaID";
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (UslugeComboBox.SelectedItem is Usluga selectedUsluga)
            {
                var uslugaKorisnika = new UslugaKorisnika
                {
                    KorisnikID = _korisnik.KorisnikID,
                    UslugaID = selectedUsluga.UslugaID
                };

                _context.UslugeKorisnika.Add(uslugaKorisnika);
                _context.SaveChanges();

                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Odaberite uslugu.", "Greška", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
