using System;
using System.Windows;
using System.Windows.Controls;
using todo.Repository;
using TodoEntities;

namespace todo.View
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        UserRepository userRepository = new UserRepository();

        public Registration()
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
            instance.Opacity = 0.4;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Переход на страницу входа
            NavigationService.Navigate(new Uri("View/LogIn.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var userRepo = new UserRepository();
            bool success = userRepo.RegisterUser(nameTB.Text, emailTB.Text, passwordTB.Text);

            string email = emailTB.Text;
            string password = passwordTB.Text;
            string name = nameTB.Text;

            if (!name.ValidateName())
            {
                MessageBox.Show("Имя должно содержать 3 или более символов");
                return;
            }

            if (!email.ValidateEmail())
            {
                MessageBox.Show("Некорректная почта");
                return;
            }

            if (!password.ValidatePassword())
            {
                MessageBox.Show("Пароль должен содержать 6 символов или более");
                return;
            }

            if (passwordTB.Text != againPasswordTB.Text)
            {
                MessageBox.Show("Пароли должны совпадать");
                return;
            }

            if (!success)
            {
                MessageBox.Show("Почта уже занята");
                return;
            }

            if (email.ValidateEmail() && password.ValidatePassword() && name.ValidateName())
            {
                if (success)
                {
                    MessageBox.Show("Регистрация прошла успешно!");
                }
                else
                {
                    MessageBox.Show("Почта уже занята. Пожалуйста, введите другой адрес электронной почты");
                }
            }

            // Переход на страницу входа после успешной регистрации
            NavigationService.Navigate(new Uri("View/LogIn.xaml", UriKind.Relative));
        }
    }
}