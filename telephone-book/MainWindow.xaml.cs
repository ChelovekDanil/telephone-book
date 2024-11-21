using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using telephone_book;

namespace telephone_book
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.Content = new AuthPage();
        }
    }
}