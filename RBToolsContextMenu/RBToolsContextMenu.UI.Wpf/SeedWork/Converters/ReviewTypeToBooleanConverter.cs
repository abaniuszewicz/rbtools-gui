using System;
using System.Globalization;
using System.Windows.Data;
using RBToolsContextMenu.UI.Wpf.Models;

namespace RBToolsContextMenu.UI.Wpf.SeedWork.Converters
{
    public class ReviewTypeToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            
            var type = (ReviewType)value;
            var result = type switch
            {
                ReviewType.New => true,
                ReviewType.Update => false,
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };

            if (parameter as string is not "invert")
                return result;

            return !result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            
            var result = (bool)value
                ? ReviewType.New
                : ReviewType.Update;

            var invert = parameter as string is "invert";
            return result switch
            {
                ReviewType.New when invert => ReviewType.Update,
                ReviewType.Update when invert => ReviewType.New,
                _ => result,
            };
        }
    }
}
