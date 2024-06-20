using AsgardGym.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;

namespace AsgardGym.Views
{
    public partial class PrisutnostView : UserControl
    {
        private GymContext _context;
        public event EventHandler GotovoClicked;

        public PrisutnostView()
        {
            InitializeComponent();
            _context = new GymContext();
            LoadData();
        }

        private void LoadData()
        {
            KorisniciComboBox.ItemsSource = _context.Korisnici
                .Select(k => new { k.KorisnikID, ImePrezime = k.Ime + " " + k.Prezime })
                .ToList();
            UslugeComboBox.ItemsSource = _context.Usluge.ToList();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search(sender, e);
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            if (KorisniciComboBox.SelectedValue is int korisnikID &&
                UslugeComboBox.SelectedValue is int uslugaID)
            {
                var posjete = _context.Posjete
                    .Where(p => p.KorisnikID == korisnikID && p.UslugaID == uslugaID)
                    .Include(p => p.Korisnik)
                    .Include(p => p.Usluga)
                    .ToList();

                PosjeteDataGrid.ItemsSource = posjete;
                UpdateUkupnoDolazaka(posjete.Count);
            }
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (KorisniciComboBox.SelectedValue is int korisnikID &&
                UslugeComboBox.SelectedValue is int uslugaID)
            {
                var novaPosjeta = new Posjeta
                {
                    KorisnikID = korisnikID,
                    UslugaID = uslugaID,
                    DatumPosjete = DateTime.Now
                };

                _context.Posjete.Add(novaPosjeta);
                _context.SaveChanges();

                Search(sender, e);
            }
            else
            {
                MessageBox.Show("Odaberite korisnika i uslugu.", "Greška", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Izbrisi_Click(object sender, RoutedEventArgs e)
        {
            if (PosjeteDataGrid.SelectedItem is Posjeta selectedPosjeta)
            {
                MessageBoxResult result = MessageBox.Show("Jeste li sigurni da želite izbrisati odabranu posjetu?", "Brisanje posjete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _context.Posjete.Remove(selectedPosjeta);
                    _context.SaveChanges();

                    Search(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Odaberite posjetu koju želite izbrisati.", "Greška", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Gotovo_Click(object sender, RoutedEventArgs e)
        {
            GotovoClicked?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateUkupnoDolazaka(int count)
        {
            UkupnoDolazakaTextBlock.Text = count.ToString();
        }
    }
}
