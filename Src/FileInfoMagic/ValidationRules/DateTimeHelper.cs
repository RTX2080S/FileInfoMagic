using System;

namespace FileInfoMagic.ValidationRules
{
    public class DateTimeHelper
    {
        public static bool IsValidDateTimeString(string dateTimeStr)
        {
            return DateTime.TryParse(dateTimeStr, out DateTime dateTimeResult);
        }
    }
}
