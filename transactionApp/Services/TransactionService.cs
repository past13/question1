using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace transactioApp.Services
{
    using Models;
    using Models.Xml;
    using Validators;

    public class TransactionService : ITransactionService
    {         
        public TransactionService() 
        {
        }

        public List<ValidationResult> ValidateTransactions(List<TransactionItem> list) 
        {
            var validator = new TransactionValidator();
            var result = new List<ValidationResult>();

            foreach (var item in list)
            {
                var transaction = validator.Validate(item);
                if (!transaction.IsValid) {
                    result.Add(transaction);
                } 
            }
            
            return result;
        }
    }
}