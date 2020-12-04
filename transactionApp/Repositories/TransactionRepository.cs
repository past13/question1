using System.Collections.Generic;

namespace transactioApp.Repositories
{
    public class TransactionRepository : ITransactionRepository 
    {
        public TransactionRepository()
        {
        }

        public IEnumerable<int> GetTransactions()
        {
            throw new System.NotImplementedException();
        }

        public bool SaveTransactions(List<int> list)
        {
            throw new System.NotImplementedException();
        }
    }
}