using System.Windows;
using AsgardGym.Models;


namespace AsgardGym.Windows
{
    public partial class UrediUsluguWindow : Window
    {
        public Usluga usluga;
        public UrediUsluguWindow(Usluga usluga)
        {
            InitializeComponent();
            this.usluga = usluga;
            PopulateFields();
        }

        private void PopulateFields()
        {
            NazivTextBox.Text = usluga.Naziv;
            OpisTextBox.Text = usluga.Opis;
            CijenaTextBox.Text = usluga.Cijena.ToString();
        }

        private void Prihvati_Click(object sender, RoutedEventArgs e)
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

            usluga.Naziv = naziv;
            usluga.Opis = opis;
            usluga.Cijena = cijena;

            DialogResult = true;
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    }
}
