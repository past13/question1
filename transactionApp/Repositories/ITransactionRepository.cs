using System.Collections.Generic;


namespace transactioApp.Repositories
{
    using Models;
    using Models.Dto;
    using Models.Xml;

    public interface ITransactionRepository
    {
        IEnumerable<TransactionDto> GetTransactions();
        bool SaveTransaction(List<TransactionItem> list);
        IEnumerable<TransactionDto> GetTransactionsByCurrency(string currency);
        IEnumerable<TransactionDto> GetTransactionsByStatus(string status);
        IEnumerable<TransactionDto> GetTransactionsByDatePeriod(FilterDates filter);
    }
}