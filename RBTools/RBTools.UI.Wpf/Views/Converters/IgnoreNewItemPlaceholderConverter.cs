using System;
using System.Windows;
using System.Windows.Data;

namespace RBTools.UI.Wpf.Views.Converters
{
    public class IgnoreNewItemPlaceholderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value.ToString() == "{NewItemPlaceholder}")
                return Visibility.Collapsed;
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}