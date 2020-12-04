namespace transactioApp.Services
{
    using System.Threading.Tasks;
    using Models;
    public interface IFileService
    {
        Task ProcessFile(FileModel file);
    } 
}