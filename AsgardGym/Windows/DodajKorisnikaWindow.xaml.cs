using AsgardGym.Models;
using System;
using System.Windows;

namespace AsgardGym.Windows
{
    public partial class DodajKorisnikaWindow : Window
    {
        public Korisnik NoviKorisnik { get; private set; }

        public DodajKorisnikaWindow()
        {
            InitializeComponent();
        }

        private void DodajKorisnika_Click(object sender, RoutedEventArgs e)
        {
            string ime = ImeTextBox.Text;
            string prezime = PrezimeTextBox.Text;
            DateTime datumRodenja;
            string email = EmailTextBox.Text;
            string telefon = TelefonTextBox.Text;

            if (string.IsNullOrEmpty(ime))
            {
                MessageBox.Show("Ime je obavezno polje.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(prezime))
            {
                MessageBox.Show("Prezime je obavezno polje.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!DateTime.TryParseExact(DatumRodenjaTextBox.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out datumRodenja))
            {
                MessageBox.Show("Unesite ispravan datum rođenja (dd.MM.yyyy).", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email je obavezno polje.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(telefon) || telefon.Length != 10 || !long.TryParse(telefon, out _))
            {
                MessageBox.Show("Unesite ispravan telefon.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NoviKorisnik = new Korisnik
            {
                Ime = ime,
                Prezime = prezime,
                DatumRodenja = datumRodenja,
                Email = email,
                Telefon = telefon
            };

            DialogResult = true;
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
