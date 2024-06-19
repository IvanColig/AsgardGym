using AsgardGym.Models;
using System;
using System.Windows;

namespace AsgardGym.Windows
{
    public partial class UrediKorisnikaWindow : Window
    {
        public Korisnik korisnik;

        public UrediKorisnikaWindow(Korisnik korisnik)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            PopulateFields();
        }

        private void PopulateFields()
        {
            ImeTextBox.Text = korisnik.Ime;
            PrezimeTextBox.Text = korisnik.Prezime;
            DatumRodenjaTextBox.Text = korisnik.DatumRodenja.ToString("dd.MM.yyyy");
            EmailTextBox.Text = korisnik.Email;
            TelefonTextBox.Text = korisnik.Telefon;
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ImeTextBox.Text))
            {
                MessageBox.Show("Ime je obavezno polje.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(PrezimeTextBox.Text))
            {
                MessageBox.Show("Prezime je obavezno polje.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(DatumRodenjaTextBox.Text))
            {
                MessageBox.Show("Datum rođenja je obavezno polje.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!DateTime.TryParseExact(DatumRodenjaTextBox.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime datumRodenja))
            {
                MessageBox.Show("Neispravan format datuma rođenja.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                MessageBox.Show("Email je obavezno polje.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(TelefonTextBox.Text) || TelefonTextBox.Text.Length != 10 || !long.TryParse(TelefonTextBox.Text, out _))
            {
                MessageBox.Show("Unesite ispravan telefon.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            korisnik.Ime = ImeTextBox.Text;
            korisnik.Prezime = PrezimeTextBox.Text;
            korisnik.DatumRodenja = datumRodenja;
            korisnik.Email = EmailTextBox.Text;
            korisnik.Telefon = TelefonTextBox.Text;

            DialogResult = true;
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
