using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace WpfApp_ADO_NET_CodeFirst
{
    [ValueConversion(typeof(double), typeof(string))]
    public class ConverterProjectsToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StringBuilder str = new StringBuilder(1000);
            str.Append("");

            if (value is ICollection<Project> list)
                foreach (var item in list)
                {
                    str.Append(item.ProjectId + " - " + item.Title + " ( " + item.Description + ")\n");
                }

            return str.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
