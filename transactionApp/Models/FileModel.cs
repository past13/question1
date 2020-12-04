using Microsoft.AspNetCore.Http;

namespace transactioApp.Models
{
    public class FileModel
    {
        public string Name { get; set; }
        public IFormFile FileInput { get; set; }
    }
}
