using System;
using System.Text;
using System.Linq;

namespace Services
{
    using Helper;
    using Models;
    using TinyCsvParser;
    public class ParseFileService : IParseFileService
    {         
        public ParseFileService() 
        {
            SetupCsvParser();
        }

        public CsvParser<UserDetail> SetupCsvParser() 
        {
            //add boolean skip header
            CsvParserOptions csvParserOptions = new CsvParserOptions(false, ',');
            CsvReaderOptions csvReaderOptions = new CsvReaderOptions(new[] { Environment.NewLine });
            UserDetailsMapping csvMapper = new UserDetailsMapping();
            
            CsvParser<UserDetail> csvParser = new CsvParser<UserDetail>(csvParserOptions, csvMapper);

            return csvParser;
        }

        public bool parseFile(CsvFileModel file)
        {
            var csvParser = SetupCsvParser();
            var validator = new PersonValidator();

            var result = csvParser
                .ReadFromFile(file.File.FileName, Encoding.ASCII)
                // .Select(x => new { Entity = x.Result, ValidationResult = validator.Validate(x.Result) })
                // .Where(x => x.IsValid)
                // .Where(x => x.ValidationResult.IsValid)
                // .OrderBy(x => x.LastName)
                .ToList();

            return true;
        }
    }
}