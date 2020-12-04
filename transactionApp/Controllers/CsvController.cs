using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace transactioApp.Controllers
{
    using Models;
    using Services;

    [Produces("application/json")]
    [Route("api/csv")]
    public class CSVController: ControllerBase
    {
        private readonly IParseFileService _service;

        public CSVController(IParseFileService service) 
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult PostFormData([FromForm] CsvFileModel file) 
        {   
            var result = _service.parseFile(file);

            return Ok(result);
        }
    }
}

 
 
 
        