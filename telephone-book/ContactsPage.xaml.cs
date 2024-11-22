using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace telephone_book
{
    /// <summary>
    /// Логика взаимодействия для ContactsPage.xaml
    /// </summary>
    public partial class ContactsPage : Page
    {
        ContextOperations context = new ContextOperations();
        users user;
        public ContactsPage()
        {
            InitializeComponent();
        }
        public ContactsPage(users user)
        {
            InitializeComponent();
            this.user = user;
            init_component();
        }

        private void init_component()
        {
            List<contacts> contacts = context.getContacts(user);
            if (contacts == null)
            {
                return;
            }
            foreach (contacts contact in contacts)
            {
                list_view_contacts.Items.Add(contact);
            }
            frame.Content = new AddContactPage(user);
        }

        private void logout_button(object sender, EventArgs e)
        {
            frame.Content = new AuthPage();
        }

        private void me_button(object sender, EventArgs e)
        {
            frame.Content = new MePage(user);
        }

        private void add_contact_button(object sender, EventArgs e)
        {
            //frame.Content = new AddContactPage(user);
        }
    }
}
