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
using System_Booking_Sys_GUI;
using Seat_Booking_Sys_Business;

namespace System_Booking_Sys_GUI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool x = Program.Login(txtUsername.Text, txtPassword.Password.ToString());

            if (x == true)
            {
                MainMenu menu = new MainMenu();
                NavigationService.Navigate(menu);
            }
            else
                MessageBox.Show("Inoccorect login details.");

        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            Program.userLoadingCondtion = false;
            NewUser x = new NewUser();
            NavigationService.Navigate(x);
        }
    }
}
