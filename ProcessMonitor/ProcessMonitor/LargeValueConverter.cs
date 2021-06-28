using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ProcessMonitor
{
    public class LargeValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Int64 size = System.Convert.ToInt64(value);
            Int64 minSize = (parameter != null) ? System.Convert.ToInt64(parameter) : 1000;
            return size > minSize;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
