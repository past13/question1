using System.Collections.Generic;

namespace transactioApp.Services
{
    using Models.Xml;
    using Repositories;
    using Models.Dto;
    using Validators;
    using transactioApp.Models;
    using System.Threading.Tasks;
    using FluentValidation.Results;

    public class TransactionService : ITransactionService
    {         
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository) 
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TransactionDto>> GetList()
        {
            return await _repository.GetTransactions();
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionsByCurrency(string currency)
        {
            return await _repository.GetTransactionsByCurrency(currency);
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionsByDatePeriod(FilterDates filter)
        {
            return await _repository.GetTransactionsByDatePeriod(filter);
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionsByStatus(string status)
        {
            return await _repository.GetTransactionsByStatus(status);
        }

        public async Task SaveTransaction(List<TransactionItem> list)
        {
            await _repository.SaveTransaction(list);
        }

        public ErrorModel FormateErrorMessage(TransactionItem transaction, ValidationResult validatedItem)
        {
            var error = new ErrorModel();
            foreach (var er in validatedItem.Errors)
            {
                error = new ErrorModel
                {
                    TransactionId = transaction.TransactionId,
                    PropertyName = er.PropertyName,
                    ErrorMessage = er.ErrorMessage,
                };
            }

            return error;
        }

        public List<ErrorModel> ValidateTransactions(List<TransactionItem> list) 
        {
            var validator = new TransactionValidator();
            var errors = new List<ErrorModel>();

            foreach (var item in list)
            {
                var transaction = validator.Validate(item);
                if (!transaction.IsValid) {
                    errors.Add(FormateErrorMessage(item, transaction));
                } 
            }
            
            return errors;
        }
    }
}