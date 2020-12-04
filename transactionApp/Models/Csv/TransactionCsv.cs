namespace transactioAp.Models.Csv
{
    public class TransactionCsv 
    {
        public string TransactionId { get; set; }

        public string TransactionDate { get; set; }
        
        public string Status { get; set; }

        public PaymentDetailsCsv PaymentDetails { get; set; }
    }
}

