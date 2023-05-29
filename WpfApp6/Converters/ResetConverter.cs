using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp6.Converters;

public class ResetConverter : IMultiValueConverter
{

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return new object[] { values[0], values[1] };
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}