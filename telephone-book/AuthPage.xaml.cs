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
            string username = username_text_box.Text;
            string password = password_text_box.Text;

            if (!ComparePassword(password))
            {
                MessageBox.Show("Не верный пароль");
                return;
            }

            frame.Content = new ContactsPage();
        }

        private bool ComparePassword(string password)
        {
            if (password == null || password == "") {
                return false;
            }
            return true;
        }
    }
}
