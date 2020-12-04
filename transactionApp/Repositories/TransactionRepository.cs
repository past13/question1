using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace transactioApp.Repositories
{
    using Models.Xml;
    using Models.Dto;
    using AutoMapper;
    using Context;
    using Models;
    using Models.Enums;

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
            var query = _context.Transactions
                            .Include(c => c.PaymentDetails)
                            .Select(c => c);

            if (filter.FromDate != null) 
            {
                query = query.Where(q => q.TransactionDate > filter.FromDate);
            }

            if (filter.ToDate != null) 
            {
                query = query.Where(q => q.TransactionDate < filter.ToDate);
            }

            return query.ToList();
        }

        public IEnumerable<TransactionDto> GetTransactionsByStatus(string status)
        {
            var enumStatus = (TransactionStatus)Enum.Parse(typeof(TransactionStatus), status, true);
            return _context.Transactions
                            .Include(c => c.PaymentDetails)
                            .Where(x => x.Status == enumStatus);
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