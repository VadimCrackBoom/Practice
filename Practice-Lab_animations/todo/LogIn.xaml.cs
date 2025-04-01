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
using System.Windows.Media.Animation;
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
            reg.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            reg.Left = -reg.Width;
            reg.Show();
            this.Hide();

            DoubleAnimation slideIn = new DoubleAnimation
            {
                From = -reg.Width,
                To = this.Left,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseInOut }
            };

            DoubleAnimation slideOut = new DoubleAnimation
            {
                From = this.Left,
                To = this.Width,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseInOut }
            };
            slideOut.Completed += (s, _) => this.Hide();

            reg.BeginAnimation(LeftProperty, slideIn);
            this.BeginAnimation(LeftProperty, slideOut);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string email = emailTB.Text;
            string password = passwordTB.Text;

            if (!email.ValidateEmail())
            {
                // error

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
                    MainEmpty empty = new MainEmpty();
                    empty.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    empty.Left = -empty.Width;

                    empty.Show();

                    DoubleAnimation slideIn = new DoubleAnimation
                    {
                        From = -empty.Width,
                        To = this.Left,
                        Duration = TimeSpan.FromSeconds(0.5),
                        EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseInOut }
                    };

                    DoubleAnimation slideOut = new DoubleAnimation
                    {
                        From = this.Left,
                        To = this.Width,
                        Duration = TimeSpan.FromSeconds(0.5),
                        EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseInOut }
                    };

                    slideOut.Completed += (s, _) => this.Hide();

                    empty.BeginAnimation(LeftProperty, slideIn);
                    this.BeginAnimation(LeftProperty, slideOut);
                }

                else
                {
                    statusLabel.Visibility = Visibility.Visible;
                    statusLabel.Content = "Неверный email или пароль";
                }
            }
        }
    }
}