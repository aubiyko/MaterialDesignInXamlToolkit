using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace MaterialDesignThemes.Wpf.Converters
{
    public class CounterProxyFabricConverter : IValueConverter
    {
        private static readonly Lazy<CounterProxyFabricConverter> _instance = new Lazy<CounterProxyFabricConverter>();

        public static CounterProxyFabricConverter Instance => _instance.Value;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return CounterProxyFabric.Get(value as Control);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
