using System;
using System.Globalization;
using System.Windows.Controls;

namespace FileInfoMagic.ValidationRules
{
    public class DateTimeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var dateTimeStr = value as string;
            var result = DateTime.TryParse(dateTimeStr, out DateTime dateTimeResult);
            return new ValidationResult(result, null);
        }
    }
}
