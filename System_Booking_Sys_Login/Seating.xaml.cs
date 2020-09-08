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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public static List<string> seats = new List<string>();

        public List<Button> buttonSeats;

        public Page1()
        {
            InitializeComponent();
            cmbTeams.ItemsSource = Program.PopulateComboBox();
            buttonSeats = new List<Button>
            {
                btnJ10,
                btnJ9,
                btnJ8,
                btnJ7,
                btnJ6,
                btnJ5,
                btnJ4,
                btnJ3,
                btnJ2,
                btnJ1,
                btnI10,
                btnI9,
                btnI8,
                btnI7,
                btnI6,
                btnI5,
                btnI4,
                btnI3,
                btnI2,
                btnI1,
                btnH10,
                btnH9,
                btnH8,
                btnH7,
                btnH6,
                btnH5,
                btnH4,
                btnH3,
                btnH2,
                btnH1,
                btnG10,
                btnG9,
                btnG8,
                btnG7,
                btnG6,
                btnG5,
                btnG4,
                btnG3,
                btnG2,
                btnG1,
                btnF10,
                btnF9,
                btnF8,
                btnF7,
                btnF6,
                btnF5,
                btnF4,
                btnF3,
                btnF2,
                btnF1,
                btnE10,
                btnE9,
                btnE8,
                btnE7,
                btnE6,
                btnE5,
                btnE4,
                btnE3,
                btnE2,
                btnE1,
                btnD10,
                btnD8,
                btnD9,
                btnD7,
                btnD6,
                btnD5,
                btnD4,
                btnD3,
                btnD2,
                btnD1,
                btnC10,
                btnC9,
                btnC8,
                btnC7,
                btnC6,
                btnC5,
                btnC4,
                btnC3,
                btnC2,
                btnC1,
                btnB10,
                btnB9,
                btnB8,
                btnB7,
                btnB6,
                btnB5,
                btnB4,
                btnB3,
                btnB2,
                btnB1,
                btnA10,
                btnA9,
                btnA8,
                btnA7,
                btnA6,
                btnA5,
                btnA4,
                btnA3,
                btnA2,
                btnA1,
            };
            foreach(var item in buttonSeats)
            {
                item.Background = Brushes.DarkGreen;
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            seats.Clear();

            foreach(var item in buttonSeats)
            {
                if (item.Background ==  Brushes.Yellow )
                    seats.Add(item.Content.ToString());

            }
            Program.updateSeats(seats);
            MessageBox.Show("Your selection has been confirmed!");
        }
      
        private void cmbTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           seats.Clear();
            foreach(var item in Program.displaySeatsForGame(Program.selectGame(cmbTeams.SelectedItem.ToString())))
            {
               foreach(Button item2 in buttonSeats)
               {
                    if (item2.Content.ToString() == item)
                        item2.Background = Brushes.Yellow;
               }
            }

            seats.Clear();
            foreach (var item in Program.displayOccupiedSeats(Program.selectGame(cmbTeams.SelectedItem.ToString())))
            {
                foreach (Button item2 in buttonSeats)
                {
                    if (item2.Content.ToString() == item)
                        item2.Background = Brushes.DarkRed;
                }
            }

        }
       
        private void btnA1_Click(object sender, RoutedEventArgs e)
        {
            if (btnA1.Background == Brushes.DarkGreen)
            {
                btnA1.Background = Brushes.Yellow;
                seats.Add(btnA1.ContentStringFormat);
            }
            else if (btnA1.Background == Brushes.Yellow)
            {
                btnA1.Background = Brushes.DarkGreen;
                seats.Remove(btnA1.ContentStringFormat);
            }
                
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu x = new MainMenu();
            NavigationService.Navigate(x);
        }

        private void btnA2_Click(object sender, RoutedEventArgs e)
        {
            if (btnA2.Background == Brushes.DarkGreen)
            {
                btnA2.Background = Brushes.Yellow;
                seats.Add(btnA2.ContentStringFormat);
            }
            else if (btnA2.Background == Brushes.Yellow)
            {
                btnA2.Background = Brushes.DarkGreen;
                seats.Remove(btnA2.ContentStringFormat);
            }
        }

        private void btnA9_Click(object sender, RoutedEventArgs e)
        {
            if (btnA9.Background == Brushes.DarkGreen)
            {
                btnA9.Background = Brushes.Yellow;
                seats.Add(btnA9.ContentStringFormat);
            }
            else if (btnA9.Background == Brushes.Yellow)
            {
                btnA9.Background = Brushes.DarkGreen;
                seats.Remove(btnA9.ContentStringFormat);
            }
        }

        private void btnA4_Click(object sender, RoutedEventArgs e)
        {
            if (btnA4.Background == Brushes.DarkGreen)
            {
                btnA4.Background = Brushes.Yellow;
                seats.Add(btnA4.ContentStringFormat);
            }
            else if (btnA4.Background == Brushes.Yellow)
            {
                btnA4.Background = Brushes.DarkGreen;
                seats.Remove(btnA4.ContentStringFormat);
            }
        }

        private void btnA5_Click(object sender, RoutedEventArgs e)
        {
            if (btnA5.Background == Brushes.DarkGreen)
            {
                btnA5.Background = Brushes.Yellow;
                seats.Add(btnA5.ContentStringFormat);
            }
            else if (btnA5.Background == Brushes.Yellow)
            {
                btnA5.Background = Brushes.DarkGreen;
                seats.Remove(btnA5.ContentStringFormat);
            }
        }

        private void btnA6_Click(object sender, RoutedEventArgs e)
        {
            if (btnA6.Background == Brushes.DarkGreen)
            {
                btnA6.Background = Brushes.Yellow;
                seats.Add(btnA6.ContentStringFormat);
            }
            else if (btnA6.Background == Brushes.Yellow)
            {
                btnA6.Background = Brushes.DarkGreen;
                seats.Remove(btnA6.ContentStringFormat);
            }
        }

        private void btnA7_Click(object sender, RoutedEventArgs e)
        {
            if (btnA7.Background == Brushes.DarkGreen)
            {
                btnA7.Background = Brushes.Yellow;
                seats.Add(btnA7.ContentStringFormat);
            }
            else if (btnA7.Background == Brushes.Yellow)
            {
                btnA7.Background = Brushes.DarkGreen;
                seats.Remove(btnA7.ContentStringFormat);
            }

        }

        private void btnA8_Click(object sender, RoutedEventArgs e)
        {
            if (btnA8.Background == Brushes.DarkGreen)
            {
                btnA8.Background = Brushes.Yellow;
                seats.Add(btnA8.ContentStringFormat);
            }
            else if (btnA8.Background == Brushes.Yellow)
            {
                btnA8.Background = Brushes.DarkGreen;
                seats.Remove(btnA8.ContentStringFormat);
            }
        }

        private void btnA3_Click(object sender, RoutedEventArgs e)
        {
            if (btnA3.Background == Brushes.DarkGreen)
            {
                btnA3.Background = Brushes.Yellow;
                seats.Add(btnA3.ContentStringFormat);
            }
            else if (btnA3.Background == Brushes.Yellow)
            {
                btnA3.Background = Brushes.DarkGreen;
                seats.Remove(btnA3.ContentStringFormat);
            }
        }

        private void btnA10_Click(object sender, RoutedEventArgs e)
        {
            if (btnA10.Background == Brushes.DarkGreen)
            {
                btnA10.Background = Brushes.Yellow;
                seats.Add(btnA10.ContentStringFormat);
            }
            else if (btnA10.Background == Brushes.Yellow)
            {
                btnA10.Background = Brushes.DarkGreen;
                seats.Remove(btnA10.ContentStringFormat);
            }
        }

        private void btnB1_Click(object sender, RoutedEventArgs e)
        {
            if (btnB1.Background == Brushes.DarkGreen)
            {
                btnB1.Background = Brushes.Yellow;
                seats.Add(btnB1.ContentStringFormat);
            }
            else if (btnB1.Background == Brushes.Yellow)
            {
                btnB1.Background = Brushes.DarkGreen;
                seats.Remove(btnB1.ContentStringFormat);
            }
        }

        private void btnB2_Click(object sender, RoutedEventArgs e)
        {
            if (btnB2.Background == Brushes.DarkGreen)
            {
                btnB2.Background = Brushes.Yellow;
                seats.Add(btnB2.ContentStringFormat);
            }
            else if (btnB2.Background == Brushes.Yellow)
            {
                btnB2.Background = Brushes.DarkGreen;
                seats.Remove(btnB2.ContentStringFormat);
            }
        }

        private void btnB3_Click(object sender, RoutedEventArgs e)
        {
            if (btnB3.Background == Brushes.DarkGreen)
            {
                btnB3.Background = Brushes.Yellow;
                seats.Add(btnB3.ContentStringFormat);
            }
            else if (btnB3.Background == Brushes.Yellow)
            {
                btnB3.Background = Brushes.DarkGreen;
                seats.Remove(btnB3.ContentStringFormat);
            }
        }

        private void btnB4_Click(object sender, RoutedEventArgs e)
        {
            if (btnB4.Background == Brushes.DarkGreen)
            {
                btnB4.Background = Brushes.Yellow;
                seats.Add(btnB4.ContentStringFormat);
            }
            else if (btnB4.Background == Brushes.Yellow)
            {
                btnB4.Background = Brushes.DarkGreen;
                seats.Remove(btnB4.ContentStringFormat);
            }
        }

        private void btnB5_Click(object sender, RoutedEventArgs e)
        {
            if (btnB5.Background == Brushes.DarkGreen)
            {
                btnB5.Background = Brushes.Yellow;
                seats.Add(btnB5.ContentStringFormat);
            }
            else if (btnB5.Background == Brushes.Yellow)
            {
                btnB5.Background = Brushes.DarkGreen;
                seats.Remove(btnB5.ContentStringFormat);
            }
        }

        private void btnB6_Click(object sender, RoutedEventArgs e)
        {
            if (btnB6.Background == Brushes.DarkGreen)
            {
                btnB6.Background = Brushes.Yellow;
                seats.Add(btnB6.ContentStringFormat);
            }
            else if (btnB6.Background == Brushes.Yellow)
            {
                btnB6.Background = Brushes.DarkGreen;
                seats.Remove(btnB6.ContentStringFormat);
            }
        }

        private void btnB7_Click(object sender, RoutedEventArgs e)
        {
            if (btnB7.Background == Brushes.DarkGreen)
            {
                btnB7.Background = Brushes.Yellow;
                seats.Add(btnB7.ContentStringFormat);
            }
            else if (btnB7.Background == Brushes.Yellow)
            {
                btnB7.Background = Brushes.DarkGreen;
                seats.Remove(btnB7.ContentStringFormat);
            }
        }

        private void btnB8_Click(object sender, RoutedEventArgs e)
        {
            if (btnB8.Background == Brushes.DarkGreen)
            {
                btnB8.Background = Brushes.Yellow;
                seats.Add(btnB8.ContentStringFormat);
            }
            else if (btnB8.Background == Brushes.Yellow)
            {
                btnB8.Background = Brushes.DarkGreen;
                seats.Remove(btnB8.ContentStringFormat);
            }
        }

        private void btnB9_Click(object sender, RoutedEventArgs e)
        {
            if (btnB9.Background == Brushes.DarkGreen)
            {
                btnB9.Background = Brushes.Yellow;
                seats.Add(btnB9.ContentStringFormat);
            }
            else if (btnB9.Background == Brushes.Yellow)
            {
                btnB9.Background = Brushes.DarkGreen;
                seats.Remove(btnB9.ContentStringFormat);
            }
        }

        private void btnB10_Click(object sender, RoutedEventArgs e)
        {
            if (btnB10.Background == Brushes.DarkGreen)
            {
                btnB10.Background = Brushes.Yellow;
                seats.Add(btnB10.ContentStringFormat);
            }
            else if (btnB10.Background == Brushes.Yellow)
            {
                btnB10.Background = Brushes.DarkGreen;
                seats.Remove(btnB10.ContentStringFormat);
            }
        }
    }
    

}


