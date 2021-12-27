using System;
using System.Globalization;
using System.Windows.Data;

namespace AccountingTestWPF.Mvvm.Converters
{
    public class IncomeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "Доход" : "Расход";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}