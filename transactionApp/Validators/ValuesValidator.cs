using System;
using System.Globalization;
using System.Linq;

namespace transactioApp.Validators
{
    public static class ValuesValidator 
    {
        public static bool ValidateCurrency(string currency) 
        {
            return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                        .Select(c => new RegionInfo(c.Name))
                        .Any(c => c.ISOCurrencySymbol == currency);
        }

        public static bool ValidateDecimal(string number) 
        {
            return decimal.TryParse(number, out _);
        }

        public static bool ValidDate(string date)
        {
            return DateTime.TryParseExact(date, "yyyy-MM-ddThh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
    } 
}
