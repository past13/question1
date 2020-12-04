using System;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace transactioApp.Services
{
    using Models;
    using Models.Xml;
    using Mappers;
    using CsvHelper;

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
            try { 
                using(XmlReader reader = XmlReader.Create(file.FileInput.OpenReadStream()))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(TransactionXml));
                    var transactionObject = (TransactionXml)serializer.Deserialize(reader);
                    
                    return transactionObject.Transactions;
                }
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        private List<TransactionItem> ParseCsvFile(FileModel file)
        {
            try {  
                using(var reader = new StreamReader(file.FileInput.OpenReadStream(), Encoding.Default))  

                using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) 
                {
                    csv.Configuration.HasHeaderRecord = false;
                    csv.Configuration.BadDataFound = null;
                    csv.Configuration.RegisterClassMap <CsvMapping>();  
                    var records = csv.GetRecords<TransactionItem>().ToList();  

                    return records;  
                }  

            } catch (Exception e) {  
                throw new Exception(e.Message);  
            }  
        }
    }
}