using RBTools.Application.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace RBTools.UI.Wpf.Converters
{
    class IsUpdateReviewTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is ReviewType reviewType && reviewType.IsUpdate;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
