using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace transactioApp.Services
{
    using System.Xml;
    using Models;
    using Models.Xml;

    public class FileService : IFileService
    {
        private readonly ITransactionService _service;
        public FileService(ITransactionService service) 
        {
            _service = service;
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

            using(XmlReader reader = XmlReader.Create(file.FileInput.OpenReadStream()))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TransactionXml));
                transactionObject = (TransactionXml)serializer.Deserialize(reader);
            }

            return transactionObject.Transactions;
        }

        private List<TransactionItem> ParseCsvFile(FileModel file)
        {
            throw new System.NotImplementedException();
        }
    }
}