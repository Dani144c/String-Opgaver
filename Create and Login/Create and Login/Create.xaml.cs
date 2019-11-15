using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Create : Window
    {
        //This opens the Create account window
        public Create()
        {
            InitializeComponent();
        }

        //Runs when the Back button is pressed 
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //Closes the create account window and opens the main window
            MainMenu main = new MainMenu();
            main.Show();
            this.Close();
        }
        
        //Runs when create button is pressed
        private void CreateNew_Click(object sender, RoutedEventArgs e)
        {
            //trying to read from the textfile
            int index;
            try
            {   // Open the text file using a stream reader.
                bool InUse = false;
                string line;
                string username, password;
                using (StreamReader sr = new StreamReader("Database.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Reading each line in the file and adding them to an varible
                        index = line.IndexOf(",");
                        username = line.Substring(0, index);
                        password = line.Substring(index + 1);

                        if (UsernameText.Text == username)
                        {
                            //Checking if the username entered is already in use
                            MessageBox.Show("Username already in use");
                            InUse = true;
                        }
                    }
                    //Closes the connection to the file
                    sr.Close();
                    //Runs if the username is not in use and there is input with under 16 characters
                    if (InUse == false && UsernameText.Text.Length >= 1 && PasswordText.Password.Length >= 1 && UsernameText.Text.Length <= 16 && PasswordText.Password.Length <= 16)
                    {
                        // Open the text file using a stream writer
                        using (StreamWriter write = new StreamWriter("Database.txt", true))
                        {
                            //Writes to the username and password to the file
                            write.WriteLine($"{UsernameText.Text},{PasswordText.Password}");
                        }
                        //Opens a messagebox that says that the profile has been creeated
                        MessageBox.Show("User is created");
                        //Closes the create window and opens the main window
                        MainMenu main = new MainMenu();
                        main.Show();
                        this.Close();
                    }
                    //Runs if some input is missing
                    else if (UsernameText.Text.Length == 0 || PasswordText.Password.Length == 0)
                    {
                        //Opens a messagebox that says input is missing
                        MessageBox.Show($"User not created!\nMissing input","", MessageBoxButton.OK);
                    }
                    //Runs if the input is too long
                    else if (UsernameText.Text.Length >= 17 || PasswordText.Password.Length >= 17)
                    {
                        //Opens a messagebox that says some input is too long
                        MessageBox.Show("User not created!\nUsername or password too long");
                    }
                    //If the window is still open, the focus is changed to the first position
                    this.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
                }
            }
            //If try fails, this runs
            catch (IOException t)
            {
                //Shows the fail message
                MessageBox.Show($"The file could not be read:\n{t.Message}");
            }
        }

        //If this is called, the program closes
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        //This is called from the passwordbox
        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            //If enter is pressed whilst using passwordbox
            if (e.Key == Key.Enter)
            {
                CreateNew.PerformClick();
            }
        }

        //Is called from the textbox 
        private void StackPanel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //If enter is pressed while using textbox, the cursor moves to the next position
            if (e.Key == Key.Enter)
            {
                TextBox s = e.Source as TextBox;
                if (s != null)
                {
                    s.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }

                e.Handled = true;
            }
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
