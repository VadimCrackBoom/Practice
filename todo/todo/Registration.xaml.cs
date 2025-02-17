using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using todo.Repository;
using TodoEntities;

namespace todo
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
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
            LogIn login = new LogIn();
            login.Show();
            this.Hide();
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
                // error
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
                if (success)
                {
                    MessageBox.Show("Регистрация прошла успешно!");
                }
                else
                {
                    MessageBox.Show("Почта уже занята. Пожалуйста, введите другой адрес электронной почты");
                }

            LogIn logIn = new LogIn();
            logIn.Show();
            this.Hide();

        }
    }
}