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
        }

        private void back_button(object sender, EventArgs e)
        {
            frame.Content = new ContactsPage();
        }

        private void init_compontent()
        {
            username_text_box.Text = user.login;
            number_text_box.Text = user.number;
            role_combo_box.ItemsSource = context.getRolesStrings();

        }

        private void update_button(object sender, EventArgs e)
        {
            return;
        }
    }
}
