using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using AsgardGym.Models;

namespace AsgardGym.Windows
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string korisnickoIme = KorisnickoImeTextBox.Text;
            string lozinka = LozinkaPasswordBox.Password;

            Debug.WriteLine($"Korisničko ime: {korisnickoIme}");
            Debug.WriteLine($"Lozinka: {lozinka}");

            try
            {
                if (ProvjeriLogin(korisnickoIme, lozinka))
                {
                    var homeWindow = new HomeWindow();
                    homeWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Netočno korisničko ime ili lozinka.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške: {ex.Message}");
                Debug.WriteLine(ex.ToString());
            }
        }

        private static bool ProvjeriLogin(string korisnickoIme, string lozinka)
        {
            try
            {
                using (var context = new GymContext())
                {
                    Debug.WriteLine($"Provjera prijave za korisnickoIme: {korisnickoIme}");

                    var admin = context.Admini.FirstOrDefault(a => a.KorisnickoIme == korisnickoIme);
                    Debug.WriteLine(context.Admini.Count());

                    if (admin == null)
                    {
                        Debug.WriteLine("Korisnik nije pronađen");
                        return false;
                    }

                    if (admin.Lozinka == lozinka)
                    {
                        Debug.WriteLine("Lozinka točna");
                        return true;
                    }
                    else
                    {
                        Debug.WriteLine("Pogrešna lozinka");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Došlo je do greške prilikom provjere prijave: {ex.Message}");
                throw new Exception("Greška prilikom pristupa bazi podataka.", ex);
            }
        }
    }
}
