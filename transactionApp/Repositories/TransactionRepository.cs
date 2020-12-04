using System.Collections.Generic;

namespace transactioApp.Repositories
{
    using Models.Xml;

    public class TransactionRepository : ITransactionRepository 
    {
        public TransactionRepository()
        {
        }

        public IEnumerable<int> GetTransactions()
        {
            throw new System.NotImplementedException();
        }

        public bool SaveTransaction(List<TransactionItem> list)
        {
            
            return true;
        }
    }
}