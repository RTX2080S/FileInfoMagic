using System.Globalization;
using System.Windows.Controls;

namespace FileInfoMagic.ValidationRules
{
    public class DateTimeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var dateTimeStr = value as string;
            var result = DateTimeHelper.IsValidDateTimeString(dateTimeStr);
            return new ValidationResult(result, null);
        }
    }
}
