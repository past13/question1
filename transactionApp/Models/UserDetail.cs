using System;

public enum TransactionStatus
{
    Failed,
    Approved,
    Finished
}

public class UserDetail
{
    public string TransactionId { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; }
    public DateTime TransactionDate { get; set; }
    public TransactionStatus Status  { get; set; }
}