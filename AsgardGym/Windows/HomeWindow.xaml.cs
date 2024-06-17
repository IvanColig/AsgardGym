﻿using System;
using System.Windows;
using AsgardGym.Models;
using AsgardGym.Views;

namespace AsgardGym.Windows
{
    public partial class HomeWindow : Window
    {
        private string korisnickoIme;
        public HomeWindow(string korisnickoIme)
        {
            InitializeComponent();
            this.korisnickoIme = korisnickoIme;
            PrikaziKorisnickoIme();
        }

        private void PrikaziKorisnickoIme()
        {
            KorisnickoImeTextBlock.Text = $"Logiran kao: {korisnickoIme}!";
        }
        private void BtnKorisnici_Click(object sender, RoutedEventArgs e)
        {
            
            ContentArea.Content = new KorisniciView();
        }

        private void BtnUsluge_Click(object sender, RoutedEventArgs e)
        {

            var uslugeView = new UslugeView();
            uslugeView.GotovoClicked += UslugeView_GotovoClicked;
            ContentArea.Content = uslugeView;
        }
        private void UslugeView_GotovoClicked(object sender, EventArgs e)
        {
            ContentArea.Content = null;
        }
        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Jeste li sigurni da se želite odjaviti?", "Odjava", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
        }
    }
}
