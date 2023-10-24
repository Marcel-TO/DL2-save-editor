namespace Editor_View.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class HexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string hexValue)
            {
                return hexValue;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                if (text.Length == 2 && int.TryParse(text, NumberStyles.HexNumber, culture, out _))
                {
                    return text;
                }
            }
            return null;
        }
    }
}
