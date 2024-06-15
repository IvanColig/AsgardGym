using System;
using System.Windows;
using AsgardGym.Models;
using AsgardGym.Views;

namespace AsgardGym.Windows
{
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void BtnKorisnici_Click(object sender, RoutedEventArgs e)
        {
            
            ContentArea.Content = new KorisniciView();
        }

        private void BtnAktivnosti_Click(object sender, RoutedEventArgs e)
        {
            
            ContentArea.Content = new AktivnostiView();
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
