using System;
using System.Globalization;
using System.Windows.Data;

namespace ControlMyPrivacy.ScreenController
{
    [ValueConversion(typeof(PossibleScreen), typeof(int))]
    public class PossibleScreenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (int)(value as PossibleScreen? ?? 0);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => (PossibleScreen)(value as int? ?? 0);
    }
}
