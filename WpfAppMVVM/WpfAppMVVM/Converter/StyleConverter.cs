using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfAppMVVM.Converter
{
    public class StyleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string dataValue = values[0] as string;
            Style firstStyle = values[1] as Style;
            Style secondStyle = values[2] as Style;

            return dataValue != null? dataValue.Equals("cust2") ? firstStyle : secondStyle: null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
