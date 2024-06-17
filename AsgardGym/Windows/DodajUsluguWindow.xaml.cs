using AsgardGym.Models;
using System.Windows;

namespace AsgardGym.Windows
{
    public partial class DodajUsluguWindow : Window
    {
        public Usluga NovaUsluga { get; private set; }

        public DodajUsluguWindow()
        {
            InitializeComponent();
        }

        private void DodajUslugu_Click(object sender, RoutedEventArgs e)
        {
            string naziv = NazivTextBox.Text;
            string opis = OpisTextBox.Text;
            int cijena;

            if (string.IsNullOrEmpty(naziv))
            {
                MessageBox.Show("Naziv je obavezno polje.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(opis))
            {
                MessageBox.Show("Opis je obavezno polje.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(CijenaTextBox.Text, out cijena) || cijena < 0)
            {
                MessageBox.Show("Unesite ispravnu cijenu.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NovaUsluga = new Usluga
            {
                Naziv = naziv,
                Opis = opis,
                Cijena = cijena
            };

            DialogResult = true;
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
