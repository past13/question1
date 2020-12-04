using System.Collections.Generic;

namespace transactioApp.Services
{
    using Models;
    public interface IFileService
    {
        List<int> ParseXmlFile(FileModel file);
        List<int> ParseCsvFile(FileModel file);
    } 
}