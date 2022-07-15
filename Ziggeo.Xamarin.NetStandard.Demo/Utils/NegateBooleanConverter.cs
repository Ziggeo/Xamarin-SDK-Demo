using System;
using Xamarin.Forms;

namespace Ziggeo.Xamarin.NetStandard.Demo.Utils
{
    public class NegateBooleanConverter: IValueConverter
    {
        public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
        public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}