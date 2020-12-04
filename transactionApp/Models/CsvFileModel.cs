using Microsoft.AspNetCore.Http;

namespace transactioApp.Models
{
    public class CsvFileModel
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
