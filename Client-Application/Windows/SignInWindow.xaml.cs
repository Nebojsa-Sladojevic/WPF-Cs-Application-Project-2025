using System.Windows;

namespace ClientApplication.Windows
{
    public partial class SignInWindow : Window
    {
        public SignInWindow() => InitializeComponent();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MinWidth = ActualWidth;
            MinHeight = ActualHeight;
        }
    }
}
