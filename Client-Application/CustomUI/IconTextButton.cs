using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ClientApplication.CustomUI
{
    internal class IconTextButton : Button
    {
        public Geometry IconData
        {
            get => (Geometry)GetValue(IconDataProperty);
            set => SetValue(IconDataProperty, value);
        }
        public static readonly DependencyProperty IconDataProperty =
            DependencyProperty.Register(nameof(IconData), typeof(Geometry), typeof(IconTextButton));
    }
}
