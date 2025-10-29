using ClientApplication.Windows;
using System.Windows;

namespace ClientApplication.CustomUI
{
    class NavigationPaneButton : IconTextButton
    {
        public static readonly DependencyProperty IsTogglePressedProperty =
                    DependencyProperty.Register(nameof(IsTogglePressed), typeof(bool), typeof(NavigationPaneButton), new PropertyMetadata(false));
        public bool IsTogglePressed
        {
            get => (bool)GetValue(IsTogglePressedProperty);
            set => SetValue(IsTogglePressedProperty, value);
        }
        public NavigationPaneButton()
        {
            if(MainWindow.Instance != null)
                Click += MainWindow.Instance.SelectTab;
        }
    }
}
