namespace transactioApp.Services
{
    using Models;
    public interface ITransactionService
    {
        bool ProcessTransactions(FileModel file);            
    } 
}