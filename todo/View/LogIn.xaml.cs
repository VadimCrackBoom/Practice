using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using TodoApiClient.Interfaces;

namespace todo.View
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        private readonly IApiService _apiService;

        public LogIn(IApiService apiService)
        {
            _apiService = apiService;
            InitializeComponent();
        }

        // Методы для placeholder эффекта в TextBox
        public void RemoveText(object sender, EventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = "";
                textBox.Opacity = 1;
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.Opacity = 0.4;
            }
        }

        // Переход на страницу регистрации
        private void NavigateToRegistration(object sender, RoutedEventArgs e)
        {
            var registrationPage = new Registration(_apiService);
            this.NavigationService.Navigate(registrationPage);
        }

        // Обработка входа
        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = emailTB.Text;
            string password = passwordTB.Text;

            // Валидация email
            if (!email.ValidateEmail())
            {
                ShowErrorAnimation(emailTB);
                statusLabel.Visibility = Visibility.Visible;
                statusLabel.Content = "Некорректная почта";
                return;
            }

            // Валидация пароля
            if (!password.ValidatePassword())
            {
                ShowErrorAnimation(passwordTB);
                statusLabel.Visibility = Visibility.Visible;
                statusLabel.Content = "Пароль должен содержать 6 символов или более";
                return;
            }

            try
            {
                // Пытаемся выполнить вход через API
                bool success = await _apiService.LoginAsync(email, password);

                if (success)
                {
                    MessageBox.Show("Вход выполнен успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Переход на главную страницу после успешного входа
                    NavigationService.Navigate(new MainEmpty());
                }
                else
                {
                    MessageBox.Show("Неверный email или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при входе: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Анимация ошибки для TextBox
        private void ShowErrorAnimation(TextBox textBox)
        {
            var shakeAnimation = new DoubleAnimation
            {
                From = 0,
                To = 10,
                Duration = TimeSpan.FromSeconds(0.1),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(3)
            };

            var transform = new TranslateTransform();
            textBox.RenderTransform = transform;
            transform.BeginAnimation(TranslateTransform.XProperty, shakeAnimation);
        }
    }
}