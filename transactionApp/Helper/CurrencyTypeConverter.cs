using System;
using System.Globalization;
using System.Linq;
using TinyCsvParser.TypeConverter;

namespace Helper
{
    public class TransactionLength : ITypeConverter<string>
    {
        public Type TargetType => typeof(string);

        public bool TryConvert(string value, out string result)
        {
            if (value.Length > 50)
            {    
                result = "Invoice name is too long";
                return false;
            }
            
            result = value;
            return true;
        }
    }

    public class CurrencyTypeConverter : ITypeConverter<string>
    {
        public Type TargetType => typeof(string);

        public bool TryConvert(string value, out string result)
        {
            var exist = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                        .Select(c => new RegionInfo(c.Name))
                        .Any(c => c.ISOCurrencySymbol == value);

            if (!exist) 
            {
                result = "Wrong currency";
                return false;
            }
            
            result = value;
            return true;
        }
    }
}