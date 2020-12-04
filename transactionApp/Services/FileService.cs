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
    using System.Threading.Tasks;

    public class FileService : IFileService
    {
        private readonly ITransactionService _service;
        public FileService(ITransactionService service) 
        {
            _service = service;
        }

        public async Task ProcessFile(FileModel file)
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

            var errors = _service.ValidateTransactions(items);
            if (errors.Capacity != 0) 
            {
                //TextWriter
                var tw = new StreamWriter("date.txt");
                foreach (var error in errors)
                {
                    tw.WriteLine(string.Format("{0} {1} {2}", error.ErrorMessage, error.PropertyName, error.TransactionId));
                }

                tw.Close();
                // var writeMe = "File content";
                // File.WriteAllText("output.txt", writeMe);
            }

            await _service.SaveTransaction(items);
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