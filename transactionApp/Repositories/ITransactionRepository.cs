using System.Collections.Generic;
using transactioApp.Models.Xml;

namespace transactioApp.Repositories
{
    public interface ITransactionRepository
    {
        IEnumerable<int> GetTransactions();
        bool SaveTransaction(List<TransactionItem> list);
    }
}