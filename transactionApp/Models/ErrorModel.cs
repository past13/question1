namespace transactioApp.Models
{
    public class ErrorModel
    {
        public string TransactionId { get; set; }
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}