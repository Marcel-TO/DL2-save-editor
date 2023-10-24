namespace Editor_View.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Controls;

    public class HexValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string hexValue)
            {
                if (hexValue.Length == 2 && int.TryParse(hexValue, NumberStyles.HexNumber, cultureInfo, out _))
                {
                    return ValidationResult.ValidResult;
                }
            }

            return new ValidationResult(false, "Enter a valid 2-character hexadecimal value.");
        }
    }
}
