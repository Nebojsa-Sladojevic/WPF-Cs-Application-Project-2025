using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ClientApplication.CustomUI
{
    internal class ButtonsGroup : StackPanel
    {
        static ButtonsGroup()
        {
            OrientationProperty.OverrideMetadata(typeof(ButtonsGroup), new FrameworkPropertyMetadata(Orientation.Horizontal));
        }
        private readonly Queue<double> _childSizes = [];
        protected override Size MeasureOverride(Size availableSize)
        {
            _childSizes.Clear();
            Size desired = new(0, 0);
            foreach (UIElement child in InternalChildren)
            {
                if (child is not ButtonBase && child is not ComboBox && child is not RadioButton)
                    throw new InvalidOperationException($"{nameof(ButtonsGroup)} can only contain Button, ComboBox, or RadioButton elements.");
                child.Measure(availableSize);
                if (Orientation == Orientation.Vertical)
                {
                    _childSizes.Enqueue(child.DesiredSize.Height);
                    desired.Height += child.DesiredSize.Height;
                    desired.Width = Math.Max(desired.Width, child.DesiredSize.Width);
                }
                else
                {
                    _childSizes.Enqueue(child.DesiredSize.Width);
                    desired.Width += child.DesiredSize.Width;
                    desired.Height = Math.Max(desired.Height, child.DesiredSize.Height);
                }
            }
            return desired;
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            double offset = 0;
            bool first = true;
            foreach (UIElement child in InternalChildren)
            {
                if (child is Control ctrl)
                {
                    ctrl.Margin = new Thickness(0);
                    ctrl.BorderThickness = first
                        ? new Thickness(1)
                        : Orientation == Orientation.Horizontal
                            ? new Thickness(0, 1, 1, 1)
                            : new Thickness(1, 0, 1, 1);
                }
                if (Orientation == Orientation.Vertical)
                {
                    double height = _childSizes.Dequeue();
                    child.Arrange(new Rect(0, offset, finalSize.Width, height));
                    offset += height;
                }
                else
                {
                    double width = _childSizes.Dequeue();
                    child.Arrange(new Rect(offset, 0, width, finalSize.Height));
                    offset += width;
                }
                first = false;
            }
            return finalSize;
        }
    }
}
