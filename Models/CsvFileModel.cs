using Microsoft.AspNetCore.Http;

namespace Models
{
    public class CsvFileModel
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
