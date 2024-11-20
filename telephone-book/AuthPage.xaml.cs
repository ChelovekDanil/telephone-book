using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace telephone_book
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string typedUsername = username_text_box.Text;
            string typedPassword = password_text_box.Text;

            if (typedUsername == "" || typedPassword == "")
            {
                MessageBox.Show("type all a fields");
                return;
            }

            users user = getUser(typedUsername);

            if (!ComparePassword(typedPassword, user.password)) {
                MessageBox.Show("wrong password");
                return;
            }
            
            frame.Content = new ContactsPage();
        }

        private users getUser(string username)
        {
            users user;

            using (var context = new telephone_bookEntities())
            {
                user = context.users.Find(username);
            }

            return user;
        }

        private bool ComparePassword(string typedPassword, string neededPassword)
        {
            if (typedPassword != neededPassword)
            {
                return false;
            }
            return true;
        }
    }
}
