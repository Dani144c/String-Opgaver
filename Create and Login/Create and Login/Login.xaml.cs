using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.IO;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        //Opens the Login window
        public Login()
        {
            InitializeComponent();
            //calls in the method DatabaseRead
            DatabaseRead();
        }

        //Is called when the back button is pressed
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //Closes the login window and opens the main menu window
            MainMenu main = new MainMenu();
            main.Show();
            this.Close();
        }

        //Is called from the login button
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            int index;
            try
            {   // Open the text file using a stream reader.
                string line;
                string username, password;
                using (StreamReader sr = new StreamReader("Database.txt"))
                {
                    //Reads every line in the text file
                    while ((line = sr.ReadLine()) != null)
                    {
                        index = line.IndexOf(",");
                        username = line.Substring(0, index);
                        password = line.Substring(index + 1);
                        //Checks if the chosen name and the name in the line is the same (else a message will be shown for every line in the file)
                        if (ComboBox1.Text == username)
                        {
                            //Checks if the password matches
                            if (PasswordText.Password == password)
                            {
                                //Shows a messagebox that says you logged in
                                MessageBox.Show("You are logged in!");
                                //Opens the account window with the varibles and closes the login window
                                Account account = new Account(ComboBox1.Text, PasswordText.Password);
                                account.Show();
                                this.Close();
                            }
                            else
                            {
                                //If none matches, the login fails
                                MessageBox.Show("Log in failed!");
                            }
                        }
                    }
                }
            }
            //If try fails, this runs
            catch (IOException t)
            {
                //Shows the fail message
                MessageBox.Show($"The file could not be read:\n{t.Message}");
            }
        }
        
        private void DatabaseRead()
        {
            int index;
            try
            {   // Open the text file using a stream reader.
                string line;
                string username, password;
                using (StreamReader sr = new StreamReader("Database.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Reading each line in the file
                        index = line.IndexOf(",");
                        username = line.Substring(0, index);
                        password = line.Substring(index + 1);

                        ComboBox1.Items.Add(username);
                        //Adding a item to the combobox with the username of each line
                    }
                }
            }
            //If try fails, this runs
            catch (IOException e)
            {
                //Shows the fail message
                MessageBox.Show($"The file could not be read:\n{e.Message}");
            }
        }

        //This class is called from the combobox
        private void StackPanel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //If enter is pressed the cursor moves to the next position
            if (e.Key == Key.Enter)
            {
                ComboBox s = e.Source as ComboBox;
                if (s != null)
                {
                    s.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }

                e.Handled = true;
            }
        }

        //Is called from the passwordbox
        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            //If enter is pressed, the performClick method is called to login button
            if (e.Key == Key.Enter)
            {
                LoginButton.PerformClick();
            }
        }
        //Exits the program when the escape button is pressed
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        //Makes the window dragable
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

    //Is called from other methods
    public static class MyExt
    {
        //When called with a button reference, it performs a click on the button
        public static void PerformClick(this Button Button)
        {
            Button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
    }
}