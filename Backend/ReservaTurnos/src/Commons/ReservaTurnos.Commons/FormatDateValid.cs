using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
