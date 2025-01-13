using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

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
            // Код для обработки клика на другую кнопку (если нужно)
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
                    SaveUserData(name, email, password); // Сохранение данных пользователя
                    LogIn login = new LogIn();
                    login.Show();
                    MessageBox.Show("Вы успешно зарегистрировались!");
                    this.Close();
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

        private void SaveUserData(string name, string email, string password)
        {
            string filePath = "C:\\Users\\student\\Desktop\\Todo.Desktop\\todo\\todo\\Repository\\Users.txt";
            string userData = $"{name};{email};{password}";

            try
            {
                // Сохраняем данные в текстовый файл
                File.AppendAllText(filePath, userData + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
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

        private void nameTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
