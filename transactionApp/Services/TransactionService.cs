using System.Collections.Generic;
using FluentValidation.Results;

namespace transactioApp.Services
{
    using Models.Xml;
    using Repositories;
    using Validators;

    public class TransactionService : ITransactionService
    {         
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository) 
        {
            _repository = repository;
        }

        public bool SaveTransaction(List<TransactionItem> list)
        {
            return _repository.SaveTransaction(list);
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