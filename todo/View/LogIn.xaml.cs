using System;
using System.Windows;
using System.Windows.Controls;
using todo.Repository;

namespace todo.View
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        public LogIn()
        {
            InitializeComponent();
        }

        public void RemoveText(object sender, EventArgs e)
        {
            TextBox instance = (TextBox)sender;
            if (instance.Text == instance.Tag.ToString())
                instance.Text = "";
            instance.Opacity = 1;
        }

        public void AddText(object sender, EventArgs e)
        {
            TextBox instance = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(instance.Text))
                instance.Text = instance.Tag.ToString();
            if (instance.Text != "")
                instance.Opacity = 0.4;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Переход на страницу регистрации
            Registration regPage = new Registration();
            this.NavigationService.Navigate(regPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string email = emailTB.Text;
            string password = passwordTB.Text;

            if (!email.ValidateEmail())
            {
                // Ошибка: некорректная почта
                MessageBox.Show("Некорректная почта");
                return;
            }

            if (!password.ValidatePassword())
            {
                MessageBox.Show("Пароль должен содержать 6 символов или более");
                return;
            }

            if (email.ValidateEmail() && password.ValidatePassword())
            {
                var userRep = new UserRepository();
                var user = userRep.GetUser(emailTB.Text, passwordTB.Text);

                if (user != null)
                {
                    MessageBox.Show($"Вход выполнен успешно!");
                    MainEmpty mainEmptyPage = new MainEmpty();
                    this.NavigationService.Navigate(mainEmptyPage);
                }
                else
                {
                    MessageBox.Show("Неверный email или пароль");
                }
            }
        }
    }
}