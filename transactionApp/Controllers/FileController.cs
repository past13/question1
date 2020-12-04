using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace transactioApp.Controllers
{
    using System.IO;
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
        public async Task<IActionResult> PostFile([FromForm]FileModel file) 
        {   
            if(ModelState.IsValid)
            {
                
            }
            // if (file) 
            // {
            //     return BadRequest();                
            // }

            // await _service.ProcessFile(file);

            return Ok(2121);
        }
    }
}

 
 
 
        