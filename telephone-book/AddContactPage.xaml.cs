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
    /// Логика взаимодействия для AddContactPage.xaml
    /// </summary>
    public partial class AddContactPage : Page
    {
        users user;
        public AddContactPage()
        {
            InitializeComponent();
        }

        public AddContactPage(users user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void create_contact_button(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void back_button(object sender, RoutedEventArgs e)
        {
            frame.Content = new ContactsPage(user);
        }
    }
}
