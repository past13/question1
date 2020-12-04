using System.Collections.Generic;


namespace transactioApp.Repositories
{
    using System.Threading.Tasks;
    using Models;
    using Models.Dto;
    using Models.Xml;

    public interface ITransactionRepository
    {
        Task<IEnumerable<TransactionDto>> GetTransactions();
        Task<IEnumerable<TransactionDto>> GetTransactionsByCurrency(string currency);
        Task<IEnumerable<TransactionDto>> GetTransactionsByStatus(string status);
        Task SaveTransaction(List<TransactionItem> list);
        Task<IEnumerable<TransactionDto>> GetTransactionsByDatePeriod(FilterDates filter);
    }
}