using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            Trace.WriteLine($"{user.id}, {user.login}, {user.number}");
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
            frame.Content = new AddContactPage(user);
        }

        private void list_view_double_click(object sender, MouseButtonEventArgs e)
        {
            if (!context.checkRoot(user, 1))
            {
                MessageBox.Show("you needed permisions");
                return;
            }
            var selectedItem = list_view_contacts.SelectedItem as contacts;
            if (selectedItem != null) 
            {
                frame.Content = new UpdateContactPage(user, selectedItem);
            }
        }
    }
}
