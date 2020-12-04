using System.Collections.Generic;
using FluentValidation.Results;

namespace transactioApp.Services
{
    using Models;
    using Models.Xml;

    public interface ITransactionService
    {
        List<ValidationResult> ValidateTransactions(List<TransactionItem> list); 
    } 
}