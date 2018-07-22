using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piksel.Dearchiver.Helpers
{
    public static class StorageSizeFormatter
    {
        static readonly string[] SizeSuffixes =
          { "byte", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public static string FormatSuffixed(Int64 value, int decimalPlaces = 1, bool iec = false)
        {
            var factor = iec ? 1024 : 1000;
            decimal dValue = Math.Abs(value);
            var i = 0;
            for (; dValue >= factor; i++)
                dValue /= factor;

            if (value < 0)
                dValue = -dValue;

            var sb = new StringBuilder().Append(Math.Round(dValue, decimalPlaces)).Append(" ");
            if (i > 0)
            {
                sb.Append(SizeSuffixes[i][0]);
                if (iec) sb.Append('i');
                sb.Append(SizeSuffixes[i][1]);
            }
            else
            {
                sb.Append(SizeSuffixes[i]);
            }

            return sb.ToString();
        }
    }
}
