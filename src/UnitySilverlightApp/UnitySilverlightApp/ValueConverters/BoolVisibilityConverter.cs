using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace UnitySilverlightApp.ValueConverters
{
    public class BoolVisibilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            const string SQAURE = "square";
            var preferSquare = (bool) value;
            var isSquare = parameter.ToString();

            if(isSquare.Equals(SQAURE, StringComparison.InvariantCultureIgnoreCase))
            {
                return preferSquare ? Visibility.Visible : Visibility.Collapsed;
            }

            return preferSquare ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
