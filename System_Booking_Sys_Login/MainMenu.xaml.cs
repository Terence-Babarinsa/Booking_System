using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Seat_Booking_Sys_Business;

namespace System_Booking_Sys_GUI
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnBookSeats_Click(object sender, RoutedEventArgs e)
        {
            Page1 seating = new Page1();
            NavigationService.Navigate(seating);
        }

        private void tbnEditProfile_Click(object sender, RoutedEventArgs e)
        {
            Program.userLoadingCondtion = true;
            NewUser newuser = new NewUser();
            NavigationService.Navigate(newuser);

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginPage login = new LoginPage();
            NavigationService.Navigate(login);
        }
    }
}
