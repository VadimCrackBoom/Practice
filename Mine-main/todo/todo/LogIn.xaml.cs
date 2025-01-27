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
using todo.Repository;

namespace todo
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
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
            Registration reg = new Registration();
            reg.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string email = emailTB.Text;
            string password = passwordTB.Text;

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

            if (email.ValidateEmail() && password.ValidatePassword())
            {
                var userRep = new UserRepository();
                var user = userRep.GetUser(emailTB.Text, passwordTB.Text);

                if (user != null)
                {
                    MessageBox.Show($"Вход выполнен успешно!");
                    Main main = new Main();
                    main.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Неверный email или пароль");
                }
            }
        }
    }
}