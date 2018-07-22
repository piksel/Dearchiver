using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Globalization;

namespace Piksel.SettingsHelper
{

    public class DecimalConverterPercent : DecimalConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value != null && value is string)
            {
                decimal v = Decimal.Parse(((string)value).Replace("%", ""));
                return v / 100M;
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value != null && value is decimal)
            {
                return ((decimal)value * 100).ToString("g4") + "%";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
