using Microsoft.AspNetCore.Mvc;

namespace transactioApp.Controllers
{
    using Models;
    using Services;
    using Validators;

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
            var result = _service.GetList();

            return Ok(result);
        }

        [HttpGet("currency/{currency}")]
        public IActionResult GetByCurrency(string currency) 
        {
            var exist = ValuesValidator.ValidateCurrency(currency);

            if (!exist) 
            {
                return BadRequest("Currency doesn't exist");
            }

            var result = _service.GetTransactionsByCurrency(currency);

            return Ok(result);
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