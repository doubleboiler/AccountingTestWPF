using System;
using System.Globalization;
using System.Windows.Data;

namespace AccountingTestWPF.Mvvm.Converters
{
    class IsAdminToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "Администратор" : "Пользователь";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
