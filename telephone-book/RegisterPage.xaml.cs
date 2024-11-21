using System;
using System.Collections;
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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        ContextOperations context = new ContextOperations();
        public RegisterPage()
        {
            InitializeComponent();
            role_combo_box.ItemsSource = context.getRolesStrings();
        }

        private void register_button(object sender, RoutedEventArgs e)
        {
            if (username_text_box.Text == "" || number_text_box.Text == "" || role_combo_box.Text == "" || password_text_box.Text == "")
            {
                MessageBox.Show("enter the entire field");
                return;
            }
            Dictionary<string, int> roles = context.getRolesTable();
            users user = new users { login = username_text_box.Text, number = number_text_box.Text, role_id = roles[role_combo_box.Text], password = password_text_box.Text };
            if (!context.saveUser(user)) 
                return;
            frame.Content = new ContactsPage(user);
        }

        private void log_in_button(object sender, RoutedEventArgs e)
        {
            frame.Content = new AuthPage();
        }
    }
}
