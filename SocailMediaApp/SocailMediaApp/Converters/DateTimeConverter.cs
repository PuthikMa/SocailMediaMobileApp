using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SocailMediaApp.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public DateTimeConverter()
        {

        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = value.ToString();
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
