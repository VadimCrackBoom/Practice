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

namespace todo
{
    /// <summary>
    /// Логика взаимодействия для MainEmpty.xaml
    /// </summary>
    public partial class MainEmpty : Window
    {
        public MainEmpty()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main main = new Main();
            main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            main.Left = -main.Width;
            main.Show();

            DoubleAnimation slideIn = new DoubleAnimation
            {
                From = -main.Width,
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

            main.BeginAnimation(LeftProperty, slideIn);
            this.BeginAnimation(LeftProperty, slideOut);
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Animations.Anim.ButtonBlurOn(sender, e);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Animations.Anim.ButtonBlurOff(sender, e);
        }
    }
}
