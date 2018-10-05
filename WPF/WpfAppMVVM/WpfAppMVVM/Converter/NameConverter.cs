using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfAppMVVM.ViewModel;

namespace WpfAppMVVM.Converter
{
    public class NameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && !String.IsNullOrEmpty(values[0].ToString()) && !String.IsNullOrEmpty(values[1].ToString()))
            {
                var value1 = values[0].ToString();
                var value2 = values[1].ToString();
                return value1 + " " + value2;
                
            }
            return string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            string[] splittedString = value.ToString().Split(' ');
            return splittedString;
        }
    }
}
