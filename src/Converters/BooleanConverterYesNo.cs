using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Globalization;

namespace Piksel.SettingsHelper
{

    public class BooleanConverterYesNo : BooleanConverter
    {
        protected virtual string Truthy => "Yes";
        protected virtual string Falsy => "No";

        protected virtual StringComparison ValComp => StringComparison.InvariantCultureIgnoreCase;

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if(value != null && value is string sval)
            {
                if (sval.Equals(Truthy, ValComp)) return true;
                if (sval.Equals(Falsy, ValComp)) return false;
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
            => (destinationType == typeof(string) && value != null && value is bool b)
                ? (b ? Truthy : Falsy)
                : base.ConvertTo(context, culture, value, destinationType);
    }

    public class BooleanConverterYesNoSwedish : BooleanConverterYesNo
    {
        protected override string Truthy => "Ja";
        protected override string Falsy => "Nej";
    }

}
