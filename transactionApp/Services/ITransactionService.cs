using System.Collections.Generic;
using FluentValidation.Results;

namespace transactioApp.Services
{
    using Models.Xml;
    using Models.Dto;
    using Models;

    public interface ITransactionService
    {
        IEnumerable<TransactionDto> GetList();
        bool SaveTransaction(List<TransactionItem> list);
        List<ValidationResult> ValidateTransactions(List<TransactionItem> list);
        IEnumerable<TransactionDto> GetTransactionsByCurrency(string currency);
        IEnumerable<TransactionDto> GetTransactionsByStatus(string status);
        IEnumerable<TransactionDto> GetTransactionsByDatePeriod(FilterDates filter);
    } 
}