using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace todo.Animations
{
    public class Anim
    {
        public static void ButtonBlurOn(object sender, RoutedEventArgs e)
        {
            Button instance = (Button)sender;

            DoubleAnimation blurAnim = new DoubleAnimation(10, TimeSpan.FromSeconds(0.3));
            ((DropShadowEffect)instance.Effect).BeginAnimation(DropShadowEffect.BlurRadiusProperty, blurAnim);
        }

        public static void ButtonBlurOff(object sender, RoutedEventArgs e)
        {
            Button instance = (Button)sender;

            DoubleAnimation blurAnim = new DoubleAnimation(0, TimeSpan.FromSeconds(0.3));
            ((DropShadowEffect)instance.Effect).BeginAnimation(DropShadowEffect.BlurRadiusProperty, blurAnim);
        }

        public static void TextBoxShake(object sender, RoutedEventArgs e)
        {
            TextBox instance_1 = (TextBox)sender;

            DoubleAnimation shakeAnimation = new DoubleAnimation
            {
                From = 0,
                To = 10,
                Duration = TimeSpan.FromSeconds(0.1),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(3)
            };

            var transform = new TranslateTransform();
            instance_1.RenderTransform = transform;

            transform.BeginAnimation(TranslateTransform.XProperty, shakeAnimation);
        }
    }
}
