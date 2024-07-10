using System;
using System.Globalization;

namespace ReservaTurnos.Commons
{
    public static class FormatDateValid
    {
        public static bool isFormatDateValid(string date)
        {
            DateTime result;
            return DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
        }
    }
}
