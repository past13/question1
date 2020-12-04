using System.Collections.Generic;

namespace transactioApp.Repositories
{
    public interface ITransactionRepository
    {
        IEnumerable<int> GetTransactions();
        bool SaveTransactions(List<int> list);
    }
}