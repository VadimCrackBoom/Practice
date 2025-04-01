using System;
using System.Windows;
using System.Windows.Controls;

namespace todo.View
{
    /// <summary>
    /// Логика взаимодействия для MainEmpty.xaml
    /// </summary>
    public partial class MainEmpty : Page
    {
        public MainEmpty()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Переход на страницу Main
            NavigationService.Navigate(new Uri("View/Main.xaml", UriKind.Relative));
        }
    }
}