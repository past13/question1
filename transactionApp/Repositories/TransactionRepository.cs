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
    using System.Threading.Tasks;

    public class TransactionRepository : ITransactionRepository 
    {
        private readonly DatabaseContext _context;          
        private readonly IMapper _mapper;

        public TransactionRepository(IMapper mapper, DatabaseContext context)  
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactions()
        {
            return await _context.Transactions.Include(c => c.PaymentDetails).ToListAsync();
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionsByCurrency(string currency)
        {
            return await _context.Transactions
                            .Include(c => c.PaymentDetails)
                            .Where(x => x.PaymentDetails.CurrencyCode == currency.ToUpper())
                            .ToListAsync();
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionsByDatePeriod(FilterDates filter)
        {
            var query = await _context.Transactions
                            .Include(c => c.PaymentDetails)
                            .Select(c => c)
                            .Where(c => (filter.FromDate.HasValue && c.TransactionDate > filter.FromDate)
                            && (filter.ToDate.HasValue && c.TransactionDate < filter.ToDate)).ToListAsync();

            return query;
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionsByStatus(string status)
        {
            var enumStatus = (TransactionStatus)Enum.Parse(typeof(TransactionStatus), status, true);
            return await _context.Transactions
                            .Include(c => c.PaymentDetails)
                            .Where(x => x.Status == enumStatus)
                            .ToListAsync();
        }

        public async Task SaveTransaction(List<TransactionItem> list)
        {
            var transactionsDto = _mapper.Map<List<TransactionItem>, List<TransactionDto>>(list);
            
            await _context.Transactions.AddRangeAsync(transactionsDto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
            }
        }
    }
}