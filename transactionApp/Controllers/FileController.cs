using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace transactioApp.Controllers
{
    using Models;
    using Services;

    [Produces("application/json")]
    [Route("file")]
    public class FileController: ControllerBase
    {
        private readonly IFileService _service;

        public FileController(IFileService service) 
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult PostFile([FromForm]FileModel file) 
        {   
            var result = _service.ProcessFile(file);

            return Ok(result);
        }
    }
}

 
 
 
        