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
        ContextOperations context = new ContextOperations();
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
            if (first_name_text_box.Text == "" || last_name_text_box.Text == "" || number_text_box.Text == "")
            {
                MessageBox.Show("enter entire fields!");
                return;
            }

            contacts contact = new contacts { first_name = first_name_text_box.Text, last_name = last_name_text_box.Text, number = number_text_box.Text, user_id = user.id };
            if (!context.createContact(user, contact))
            {
                return;
            }
            MessageBox.Show("added new contact");
        }

        private void back_button(object sender, RoutedEventArgs e)
        {
            frame.Content = new ContactsPage(user);
        }
    }
}
