using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp_ADO_NET_CodeFirst
{
    [ValueConversion(typeof(double), typeof(string))]
    public class ConverterEmployeesToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StringBuilder str = new StringBuilder(1000);
            str.Append("");

            if (value is ICollection<Employee> list)
                foreach (var item in list)
                {
                    str.Append(item.FirstName + " " + item.LastName +"\n");
                }

            return str.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
