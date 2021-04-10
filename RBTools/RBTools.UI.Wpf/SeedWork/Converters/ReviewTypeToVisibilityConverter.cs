using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using RBTools.UI.Wpf.Models;

namespace RBTools.UI.Wpf.SeedWork.Converters
{
    public class ReviewTypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not ReviewType type)
                throw new ArgumentException(nameof(value));

            return type == ReviewType.New
                ? Visibility.Hidden
                : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Visibility visibility)
                throw new ArgumentException(nameof(value));

            return visibility == Visibility.Hidden
                ? ReviewType.New
                : ReviewType.Update;
        }
    }
}
