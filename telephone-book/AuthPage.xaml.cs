using System.Windows;
using System.Windows.Controls;

namespace telephone_book
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        ContextOperations context = new ContextOperations();
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Button_LogIn(object sender, RoutedEventArgs e)
        {
            string typedUsername = username_text_box.Text;
            string typedPassword = password_text_box.Text;

            if (typedUsername == "" || typedPassword == "")
            {
                MessageBox.Show("type all a fields");
                return;
            }

            users user = context.getUserByLogin(typedUsername);
            if (user == null)
            {
                MessageBox.Show("user not founded");
                return;
            }

            if (!ComparePassword(typedPassword, user.password)) {
                MessageBox.Show("wrong password");
                return;
            }
            
            frame.Content = new ContactsPage(user);
        }

        private bool ComparePassword(string typedPassword, string neededPassword)
        {
            if (typedPassword != neededPassword)
            {
                return false;
            }
            return true;
        }

        private void Button_Register(object sender, RoutedEventArgs e)
        {
            frame.Content = new RegisterPage();
        }
    }
}
