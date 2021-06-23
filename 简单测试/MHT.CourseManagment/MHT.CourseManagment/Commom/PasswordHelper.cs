using System.Windows;
using System.Windows.Controls;

namespace MHT.CourseManagment.Commom
{
    public class PasswordHelper
    {
        /// <summary>
        /// Password依赖属性
        /// </summary>
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordHelper),
                new FrameworkPropertyMetadata("", new PropertyChangedCallback(OnPropertyChanged)));

        public static string GetPassword(DependencyObject d)
        {
            return d.GetValue(PasswordProperty).ToString();
        }
        public static void SetPassword(DependencyObject d, string value)
        {
            d.SetValue(PasswordProperty, value);
        }

        public static readonly DependencyProperty AttachProperty =
           DependencyProperty.RegisterAttached("Attach", typeof(bool), typeof(PasswordHelper),
               new FrameworkPropertyMetadata(default(bool), new PropertyChangedCallback(OnAttached)));

        public static bool GetAttach(DependencyObject d)
        {
            return (bool)d.GetValue(AttachProperty);
        }
        public static void SetAttach(DependencyObject d, bool value)
        {
            d.SetValue(AttachProperty, value);
        }
        private static bool _isUpdate = false;
        /// <summary>
        /// Password属性发生变化的时候，通知前端窗体修改页面显示
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = d as PasswordBox;
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
            if (!_isUpdate)
                passwordBox.Password = e.NewValue?.ToString();
            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;

        }
        private static void OnAttached(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = d as PasswordBox;
            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            _isUpdate = true;
            SetPassword(passwordBox, passwordBox.Password);
            _isUpdate = false;

        }
    }
}
