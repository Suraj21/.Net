using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfAppMVVM.Converter
{
    public class TotalConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(values != null && !String.IsNullOrEmpty(values[0].ToString()) && !String.IsNullOrEmpty(values[1].ToString()))
            {
                decimal Amount = 0;
                decimal Discount = 0;
                string TotalAmount = string.Empty;
                Amount = (values[0] != null && values[0] != DependencyProperty.UnsetValue) ? System.Convert.ToDecimal(values[0]) : 0;
                Discount = (values[0] != null && values[1] != DependencyProperty.UnsetValue) ? System.Convert.ToDecimal(values[1]) : 0;
                TotalAmount = System.Convert.ToString(Amount - Discount);
                return TotalAmount;
            }
            return string.Empty;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
            //throw new NotImplementedException();
        }
    }
}
