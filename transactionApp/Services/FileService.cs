using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace transactioApp.Services
{
    using Models;
    using Models.Xml;
    using Repositories;

    public class FileService : IFileService
    {
        private readonly ITransactionService _service;
        public FileService() 
        {

        }

        public bool ProcessFile(FileModel file)
        {
            List<TransactionItem> items = new List<TransactionItem>();

            if (file.FileInput.ContentType == "application/xml") 
            {
                items = ParseXmlFile(file);
            }

            if (file.FileInput.ContentType == "text/csv") 
            {
                items = ParseCsvFile(file);
            }

            return true;
        }

        private List<TransactionItem> ParseXmlFile(FileModel file)
        {
            TransactionXml transactionObject = null;

            using (var fileStream = File.Open(file.FileInput.FileName, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TransactionXml));
                transactionObject = (TransactionXml)serializer.Deserialize(fileStream);
            }

            return transactionObject.Transactions;
        }

        private List<TransactionItem> ParseCsvFile(FileModel file)
        {
            throw new System.NotImplementedException();
        }
    }
}