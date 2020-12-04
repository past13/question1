using System.Collections.Generic;
using FluentValidation.Results;

namespace transactioApp.Services
{
    using Models;
    using Models.Xml;

    public interface ITransactionService
    {
        bool SaveTransaction(List<TransactionItem> list);
        List<ValidationResult> ValidateTransactions(List<TransactionItem> list); 
    } 
}