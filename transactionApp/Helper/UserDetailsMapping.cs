namespace transactioApp.Helper
{
    using TinyCsvParser.Mapping;
    using TinyCsvParser.TypeConverter;

    public class UserDetailsMapping : CsvMapping<UserDetail>
    {  
        public UserDetailsMapping()
            : base()
        {
            MapProperty(0, x => x.TransactionId, new TransactionLength());
            MapProperty(1, x => x.Amount);
            MapProperty(2, x => x.CurrencyCode, new CurrencyTypeConverter());
            MapProperty(3, x => x.TransactionDate, new DateTimeConverter("dd/MM/yyyy hh:mm:ss"));
            MapProperty(4, x => x.Status, new EnumConverter<TransactionStatus>());
        }
    }
}
