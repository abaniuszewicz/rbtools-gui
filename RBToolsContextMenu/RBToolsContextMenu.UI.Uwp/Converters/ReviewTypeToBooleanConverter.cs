using RBToolsContextMenu.UI.Uwp.Models;
using System;
using Windows.UI.Xaml.Data;

namespace RBToolsContextMenu.UI.Uwp.Converters
{
    public class ReviewTypeToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
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

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var result = (bool)value
                ? ReviewType.New
                : ReviewType.Update;

            bool invert = parameter as string is "invert";
            return result switch
            {
                ReviewType.New when invert => ReviewType.Update,
                ReviewType.Update when invert => ReviewType.New,
                _ => result,
            };
        }
    }
}
