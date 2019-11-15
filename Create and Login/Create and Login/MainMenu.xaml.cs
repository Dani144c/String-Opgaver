using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Create_and_Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        //Opens the main window
        public MainMenu()
        {
            InitializeComponent();
        }

        //Runs when Create button is pressed
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            //Makes an new object, opens the Create window and closes the main window
            Create create = new Create();
            create.Show();
            this.Close();
        }

        //Runs when Login button is pressed
        private void Login_Click(Object sender, RoutedEventArgs e)
        {
            //Makes an new object, opens the Login window and closes the main window
            Login login = new Login();
            login.Show();
            this.Close();
        }

        //If this is called, the program closes
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        //Exits the program when escape is pressed
        private void Exit(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Environment.Exit(0);
            }
        }

        //This is connected to the window, which does that you can drag the window with the mouse
        private void WindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}