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
        private readonly ITransactionService _service;

        public FileController(ITransactionService service) 
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult PostFile([FromForm]FileModel file) 
        {   
            var result = _service.ProcessTransactions(file);

            return Ok(result);
        }
    }
}

 
 
 
        