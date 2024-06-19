using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AsgardGym.Models;
using AsgardGym.Windows;

namespace AsgardGym.Views
{
    public partial class UslugeView : UserControl
    {
        private GymContext _context;
        public event EventHandler GotovoClicked;

        public UslugeView()
        {
            InitializeComponent();
            _context = new GymContext();
            LoadData();
        }

        private void LoadData()
        {
            UslugeDataGrid.ItemsSource = _context.Usluge.ToList();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            var dodajUsluguWindow = new DodajUsluguWindow();

            if (dodajUsluguWindow.ShowDialog() == true)
            {
                var novaUsluga = dodajUsluguWindow.NovaUsluga;
                _context.Usluge.Add(novaUsluga);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void Uredi_Click(object sender, RoutedEventArgs e)
        {
            if (UslugeDataGrid.SelectedItem is Usluga selectedUsluga)
            {
                var urediUsluguWindow = new UrediUsluguWindow(selectedUsluga);

                if (urediUsluguWindow.ShowDialog() == true)
                {
                    var usluga = urediUsluguWindow.usluga;
                    _context.Usluge.Update(usluga);
                    _context.SaveChanges();
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Odaberite uslugu za uređivanje.");
            }
        }

        private void Izbrisi_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Želite li ukloniti uslugu?", "Brisanje usluge", MessageBoxButton.YesNo, MessageBoxImage.Question);

            
            if (UslugeDataGrid.SelectedItem is Usluga selectedUsluga && result == MessageBoxResult.Yes)
            {
                _context.Usluge.Remove(selectedUsluga);
                _context.SaveChanges();
                LoadData();
            }
            
        }

        private void Gotovo_Click(object sender, RoutedEventArgs e)
        {
            GotovoClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
