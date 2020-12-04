using Models;

namespace Services
{
    public interface IParseFileService
    {
        bool parseFile(CsvFileModel file);            
    } 
}