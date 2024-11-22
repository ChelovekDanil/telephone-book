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
    /// Логика взаимодействия для UpdateContactPage.xaml
    /// </summary>
    public partial class UpdateContactPage : Page
    {
        ContextOperations context = new ContextOperations();
        users user;
        contacts contact;
        public UpdateContactPage()
        {
            InitializeComponent();
        }

        public UpdateContactPage(users user, contacts contact)
        {
            InitializeComponent();
            this.user = user;
            this.contact = contact;
            init_component();
        }

        private void init_component()
        {
            first_name_text_box.Text = contact.first_name;
            last_name_text_box.Text = contact.last_name;
            number_text_box.Text = contact.number;
        }

        private void back_button(object sender, EventArgs e)
        {
            frame.Content = new ContactsPage(user);
        }

        private void update_button(object sender, EventArgs e)
        {
            if (first_name_text_box.Text == "" || last_name_text_box.Text == "" || number_text_box.Text == "")
            {
                MessageBox.Show("enter entry fields");
                return;
            }

            contacts newContact = new contacts { id = contact.id, first_name = first_name_text_box.Text, last_name = last_name_text_box.Text, number = number_text_box.Text, user_id = user.id };

            if (!context.updateContact(newContact))
            {
                MessageBox.Show("error updating data");
                return;
            }
            contact = newContact;
            init_component();
            MessageBox.Show("data updated");
        }

        private void delete_button(object sender, EventArgs e)
        {
            if (context.deleteContact(contact))
            {
                frame.Content = new ContactsPage(user);
            } 
        }
    }
}
