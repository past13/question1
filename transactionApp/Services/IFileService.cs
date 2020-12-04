using System.Collections.Generic;

namespace transactioApp.Services
{
    using Models;
    public interface IFileService
    {
        bool ProcessFile(FileModel file);
    } 
}