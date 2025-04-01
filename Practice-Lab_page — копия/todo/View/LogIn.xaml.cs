using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
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

                DoubleAnimation shakeAnimation = new DoubleAnimation
                {
                    From = 0,
                    To = 10,
                    Duration = TimeSpan.FromSeconds(0.1),
                    AutoReverse = true,
                    RepeatBehavior = new RepeatBehavior(3)
                };

                var transform = new TranslateTransform();
                emailTB.RenderTransform = transform;

                transform.BeginAnimation(TranslateTransform.XProperty, shakeAnimation);

                // Ошибка: некорректная почта
                statusLabel.Visibility = Visibility.Visible;
                statusLabel.Content = "Некорректная почта";
                return;
            }

            if (!password.ValidatePassword())
            {

                DoubleAnimation shakeAnimation = new DoubleAnimation
                {
                    From = 0,
                    To = 10,
                    Duration = TimeSpan.FromSeconds(0.1),
                    AutoReverse = true,
                    RepeatBehavior = new RepeatBehavior(3)
                };

                var transform = new TranslateTransform();
                passwordTB.RenderTransform = transform;

                transform.BeginAnimation(TranslateTransform.XProperty, shakeAnimation);

                statusLabel.Visibility = Visibility.Visible;
                statusLabel.Content = "Пароль должен содержать 6 символов или более";
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