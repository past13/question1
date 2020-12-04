using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace transactioApp.Repositories
{
    using Models.Xml;
    using Models.Dto;
    using AutoMapper;
    using Context;
    using transactioApp.Models;

    public class TransactionRepository : ITransactionRepository 
    {
        private readonly DatabaseContext _context;          
        private readonly IMapper _mapper;

        public TransactionRepository(IMapper mapper, DatabaseContext context)  
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<TransactionDto> GetTransactions()
        {
            return _context.Transactions.Include(c => c.PaymentDetails).ToList();
        }

        public IEnumerable<TransactionDto> GetTransactionsByCurrency(string currency)
        {
            return _context.Transactions
                            .Include(c => c.PaymentDetails)
                            .Where(x => x.PaymentDetails.CurrencyCode == currency.ToUpper());
        }

        public IEnumerable<TransactionDto> GetTransactionsByDatePeriod(FilterDates filter)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TransactionDto> GetTransactionsByStatus(string status)
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