namespace transactioApp.Services
{
    using Models;
    public interface IParseFileService
    {
        bool parseFile(CsvFileModel file);            
    } 
}