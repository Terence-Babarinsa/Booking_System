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
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Page
    {
        
        public NewUser()
        {
            InitializeComponent();
            btnBack.Content = "Cancel";
            if (Program.userLoadingCondtion == true)
            {
               // btnBack.Visibility = Visibility.Hidden;
                btnCreateNewUser.Content = "Update";
                btnDelete.Visibility = Visibility.Visible;

                Queue<string> populateUser = Program.searchForUser();

                txtFirstName.Text = populateUser.Dequeue();
                txtLastName.Text = populateUser.Dequeue();
                txtDOB.Text = populateUser.Dequeue();
                txtAddress.Text = populateUser.Dequeue();
                txtPostcode.Text = populateUser.Dequeue();
                txtCity.Text = populateUser.Dequeue();
                txtMobile.Text = populateUser.Dequeue();
                txtUserName.Text = populateUser.Dequeue();
                txtPassword.Text = populateUser.Dequeue();

            }
        }

       

        private void btnCreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("Please enter a FirstName");
                lblFNMark.Visibility = Visibility.Visible;
            }
            else if (txtLastName.Text == "")
            {
                MessageBox.Show("Please enter a Lastname");
                lblLNMArk.Visibility = Visibility.Visible;
            }
            else if (txtDOB.Text == "")
            {
                MessageBox.Show("Please enter a Date of Birth");
                lblDOBMark.Visibility = Visibility.Visible;
            } 
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Please enter an Address");
                lblAMark.Visibility = Visibility.Visible;
            }
            else if (txtPostcode.Text == "")
            {
                MessageBox.Show("Please enter a Postcode");
                lblPMark.Visibility = Visibility.Visible;
            }
            else if (txtCity.Text == "")
            {
                MessageBox.Show("Please enter a City");
                lblCMark.Visibility = Visibility.Visible;
            }
           else if (txtMobile.Text == "")
            {
                MessageBox.Show("Please enter a Mobile number");
                lblMMark.Visibility = Visibility.Visible;
            }
            else if (txtUserName.Text == "")
            {
                MessageBox.Show("Please enter a Username");
                lblUMark.Visibility = Visibility.Visible;
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter a Password");
                lblPWMark.Visibility = Visibility.Visible;
            }    
            else if (btnCreateNewUser.Content.ToString() == "Update")
            {
                Queue<string> details = new Queue<string>();
                details.Enqueue(txtFirstName.Text);
                details.Enqueue(txtLastName.Text);
                details.Enqueue(txtDOB.Text);
                details.Enqueue(txtAddress.Text);
                details.Enqueue(txtPostcode.Text);
                details.Enqueue(txtCity.Text);
                details.Enqueue(txtMobile.Text);
                details.Enqueue(txtUserName.Text);
                details.Enqueue(txtPassword.Text);


                Program.updateUserDetails(details);
            }
            else
            {
                Program.createNewUser(txtFirstName.Text, txtLastName.Text, txtDOB.Text, txtAddress.Text, txtPostcode.Text, txtCity.Text, txtMobile.Text, txtUserName.Text, txtPassword.Text);
                MessageBox.Show("New User Added");

                LoginPage x = new LoginPage();
                NavigationService.Navigate(x);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (Program.userLoadingCondtion == false)
            {
                LoginPage x = new LoginPage();
                NavigationService.Navigate(x);
            }
            else
            {
                MainMenu main = new MainMenu();
                NavigationService.Navigate(main);
            }
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Program.deleteUser();
            MessageBox.Show("You profile has been removed");
            MainMenu x = new MainMenu();
            NavigationService.Navigate(x);
            
        }
    }
}
