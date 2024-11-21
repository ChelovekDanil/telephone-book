using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace telephone_book
{
    /// <summary>
    /// Логика взаимодействия для MePage.xaml
    /// </summary>
    public partial class MePage : Page
    {
        ContextOperations context = new ContextOperations();
        users user;
        public MePage()
        {
            InitializeComponent();
        }

        public MePage(users user)
        {
            InitializeComponent();
            this.user = user;
            init_component();
        }

        private void back_button(object sender, EventArgs e)
        {
            frame.Content = new ContactsPage(user);
        }

        private void init_component()
        {
            Dictionary<int, string> roles = context.getRolesTableKeyId();
            
            username_text_box.Text = user.login;
            number_text_box.Text = user.number;
            role_combo_box.ItemsSource = context.getRolesStrings();
            role_combo_box.Text = roles[user.role_id];
            password_text_box.Text = user.password;
        }

        private void update_button(object sender, EventArgs e)
        {
            if (username_text_box.Text == "" || number_text_box.Text == "" || role_combo_box.Text == "" || password_text_box.Text == "")
            {
                MessageBox.Show("enter the entire field");
                return;
            }

            Dictionary<string, int> roles = context.getRolesTableKeyName();
            users newUser = new users { login = username_text_box.Text, number = number_text_box.Text, role_id = roles[role_combo_box.Text], password =  password_text_box.Text };

            if (!context.updateUser(user.login, newUser)) {
                MessageBox.Show("error updating data");
                return;
            }

            user = newUser;
            init_component();
            MessageBox.Show("data updated");
        }
    }
}
