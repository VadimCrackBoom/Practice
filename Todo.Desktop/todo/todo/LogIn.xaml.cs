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
using System.Windows.Shapes;

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
                MainEmpty mainEmpty = new MainEmpty();
                mainEmpty.Show();
                this.Hide();
            }
            else
            {
                // Иначе выводим сообщение об ошибке
                string errorMessage = "Ошибка валидации:";
                if (!isEmailValid)
                    errorMessage += "\\nНеверный email.";
                if (!isPasswordValid)
                    errorMessage += "\\nПароль должен содержать не менее 6 символов.";

                MessageBox.Show(errorMessage);
            }
        }
    }
}