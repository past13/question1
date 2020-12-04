using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace transactioApp.Models
{
    public class FileModel
    {
        public string Name { get; set; }
        // [MaxFileSize(5* 1024 * 1024)]
        // [FileExtensions(Extensions = "xml", ErrorMessage = "Please select an Excel file.")]
        public IFormFile FileInput { get; set; }
    }
}
