using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Create_and_Login
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Window
    {

        //This opens the window with account infomation after login
        //It gets 2 varibles from the login page with username and password
        public Account(string username, string password)
        {
            InitializeComponent();
            UsernameText.Text = username;
            PasswordText.Text = password;
        }

        //Runs when logout button is clicked
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            //Shows a message which's says you logged off
            MessageBox.Show("You logged out!");
            //Closes the account page and opens the login page
            Login login = new Login();
            login.Show();
            this.Close();
        }

        //If this is called, the program closes
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        //This is connected to the window, which does that you can drag the window with the mouse
        private void WindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //Exits the program when escape is pressed
        private void Exit(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Environment.Exit(0);
            }
        }
    }
}
