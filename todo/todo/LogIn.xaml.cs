using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using static todo.Registration;

namespace todo
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private InputValidator _validator;

        public LogIn()
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
            Registration reg = new Registration();
            reg.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string email = emailTB.Text;
            string password = passwordTB.Text;

            bool isEmailValid = _validator.ValidateEmail(email);
            bool isPasswordValid = _validator.ValidatePassword(password);

            if (isEmailValid && isPasswordValid && emailTB.Text != "exam@yandex.ru" && passwordTB.Text != "Введите пароль")
            {
                // Проверка данных в файле пользователей
                if (VerifyUser(email, password))
                {
                    MainEmpty mainEmpty = new MainEmpty();
                    mainEmpty.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный email или пароль.");
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

                MessageBox.Show(errorMessage);
            }
        }

        private bool VerifyUser(string email, string password)
        {
            string filePath = "C:\\Users\\student\\Desktop\\Todo.Desktop\\todo\\todo\\Repository\\Users.txt";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл пользователей не найден.");
                return false;
            }

            string[] userRecords = File.ReadAllLines(filePath);
            foreach (string record in userRecords)
            {
                string[] userData = record.Split(';');
                if (userData.Length >= 3)
                {
                    string storedName = userData[0];
                    string storedEmail = userData[1];
                    string storedPassword = userData[2];

                    if (storedEmail.Equals(email, StringComparison.OrdinalIgnoreCase) && storedPassword == password)
                    {
                        return true; // Успешная проверка
                    }
                }
            }

            return false; // Проверка не удалась
        }
    }

    public class InputValidator
    {
        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string emailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            return Regex.IsMatch(email, emailPattern);
        }

        public bool ValidatePassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
        }
    }
}
