using System.Collections.Generic;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace transactioApp.Services
{
    using Models.Xml;
    using Models.Dto;
    using Models;
    using static transactioApp.Services.TransactionService;

    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetList();
        Task<IEnumerable<TransactionDto>> GetTransactionsByCurrency(string currency);
        Task<IEnumerable<TransactionDto>> GetTransactionsByDatePeriod(FilterDates filter);
        Task SaveTransaction(List<TransactionItem> list);
        Task<IEnumerable<TransactionDto>> GetTransactionsByStatus(string status);
        List<ErrorModel> ValidateTransactions(List<TransactionItem> list);
    } 
}