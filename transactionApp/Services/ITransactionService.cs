using System.Collections.Generic;
using FluentValidation.Results;

namespace transactioApp.Services
{
    using Models.Xml;
    using Models.Dto;

    public interface ITransactionService
    {
        IEnumerable<TransactionDto> GetList();
        bool SaveTransaction(List<TransactionItem> list);
        List<ValidationResult> ValidateTransactions(List<TransactionItem> list); 
    } 
}