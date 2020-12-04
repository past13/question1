using Microsoft.AspNetCore.Mvc;
using transactioApp.Models;
using transactioApp.Services;

namespace transactioApp.Controllers
{
    [Produces("application/json")]
    [Route("transaction")]
    public class TransactionContoller: ControllerBase
    {
        private readonly ITransactionService _service;
        public TransactionContoller(ITransactionService service) 
        {
            _service = service;
        }

        [HttpGet("list")]
        public IActionResult GetList() 
        {
            
            return Ok();
        }

        [HttpGet("currency/{currency}")]
        public IActionResult GetByCurrency(string currency) 
        {
            return Ok();
        }

        [HttpGet("status/{status}")]
        public IActionResult GetByStatus(string status) 
        {
            return Ok();
        }

        [HttpGet("filterbydate")]
        public IActionResult GetDate([FromBody]FilterDates filter) 
        {
            return Ok();
        }
    }
}