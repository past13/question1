using CsvHelper.Configuration;

namespace transactioApp.Mappers
{
    using Models.Xml;

    public sealed class CsvMapping : ClassMap<TransactionItem>
    {
        public CsvMapping()
        {
            Map(m => m.TransactionId).Index(0);
            Map(m => m.PaymentDetails.Amount).Index(1);;
            Map(m => m.PaymentDetails.CurrencyCode).Index(2);;
            Map(m => m.TransactionDate).Index(3);;
            Map(m => m.Status).Index(4);;
        }
    }
}
