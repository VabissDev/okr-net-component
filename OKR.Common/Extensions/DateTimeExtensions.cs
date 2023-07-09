using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime Now()
        {
            return DateTime.Now;
        }

        public static DateTime? ParseAsDate(this string input)
        {
            bool ok = DateTime.TryParseExact(input.Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

            if (ok)
                return date;

            return null;
        }

    }
}
