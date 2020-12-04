using System.Collections.Generic;

namespace transactioApp.Repositories
{
    using Models.Xml;
    using Models.Dto;
    using AutoMapper;
    using Context;

    public class TransactionRepository : ITransactionRepository 
    {
        private readonly DatabaseContext _context;          
        private readonly IMapper _mapper;

        public TransactionRepository(IMapper mapper, DatabaseContext context)  
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<int> GetTransactions()
        {
            throw new System.NotImplementedException();
        }

        public bool SaveTransaction(List<TransactionItem> list)
        {
            var transactionsDto = _mapper.Map<List<TransactionItem>, List<TransactionDto>>(list);
               
            foreach (var item in transactionsDto)
            {
                _context.Transactions.Add(item);
            }

            try
            {
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
            }

            return true;
        }
    }
}