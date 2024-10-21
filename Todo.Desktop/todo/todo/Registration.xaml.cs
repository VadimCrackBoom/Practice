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

namespace todo
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private InputValidator _validator;
        public Registration()
        {
            InitializeComponent();
            _validator = new InputValidator();
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
            string email = emailTB.Text;
            string password = passwordTB.Text;
            string name = nameTB.Text;

            bool isEmailValid = _validator.ValidateEmail(email);
            bool isPasswordValid = _validator.ValidatePassword(password);
            bool isNameValid = _validator.ValidateName(name);

            // Проверка основных условий
            if (isEmailValid && isPasswordValid && isNameValid &&
                email != "exam@yandex.ru" &&
                password != "Введите пароль" &&
                name != "Введите имя пользователя")
            {
                if (password == againPasswordTB.Text)
                {
                    MainEmpty mainEmpty = new MainEmpty();
                    mainEmpty.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают.");
                }
            }
            else
            {
                // Иначе выводим сообщение об ошибке 
                string errorMessage = "Ошибка валидации:";
                if (!isEmailValid)
                    errorMessage += "\nНеверный email.";
                if (!isPasswordValid)
                    errorMessage += "\nПароль должен содержать не менее 6 символов.";
                if (!isNameValid)
                    errorMessage += "\nИмя должно содержать не менее 3 знаков.";

                MessageBox.Show(errorMessage);
            }
        }


        private void nameTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    public class InputValidator
    {
        // Метод для проверки валидности почты
        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Паттерн для проверки email
            string emailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Метод для проверки валидности пароля
        public bool ValidatePassword(string password)
        {
            // Проверка на длину пароля
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
        }

        // Метод для проверки валидности имени
        public bool ValidateName(string name)
        {
            // Проверка на длину имени
            return !string.IsNullOrWhiteSpace(name) && name.Length >= 3;
        }
    }

}
