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
            var dateTimeNow = DateTime.UtcNow;
            var dateTime = (DateTime)value;

            var resutTime = dateTimeNow - dateTime;
            if(resutTime.Days> 365)
            {
                const int oneYear = 365;
                int resultInYear = (int)(resutTime.TotalDays / oneYear);
                return $"{resultInYear} years ago";
            }
            else if(resutTime.Days > 0)
            {
                return $"{resutTime.Days} days ago";
            }else if(resutTime.Hours > 0)
            {
                return $"{resutTime.Hours} hours ago";
            }else if(resutTime.Minutes > 0)
            {
                return $"{resutTime.Minutes} minutes ago";
            }else if (resutTime.Seconds > 0)
            {
                return $"{resutTime.Seconds} seconds ago";
            }
            else
            {
                return "just now...";
            }



        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
