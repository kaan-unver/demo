using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Utilities.Extensions
{
    public static class DecimalFormatExtension
    {
        public static decimal GetFormattedValue(this decimal value)
        {
            var formatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberGroupSeparator = ",",

            };

            string formattedString = value.ToString("N", formatInfo);
            return decimal.Parse(formattedString, NumberStyles.Currency, formatInfo);
        }
    }
}
