using System;
using Microsoft.AspNetCore.Mvc;

namespace transactioApp.Controllers
{
    using System.Threading.Tasks;
    using Models;
    using Models.Enums;
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
        public async Task<IActionResult> GetList() 
        {
            var result = await _service.GetList();

            return Ok(result);
        }

        [HttpGet("currency/{currency}")]
        public async Task<IActionResult> GetByCurrency(string currency) 
        {
            var exist = ValuesValidator.ValidateCurrency(currency);

            if (!exist) 
            {
                return BadRequest("Currency doesn't exist");
            }

            var result = await _service.GetTransactionsByCurrency(currency);

            return Ok(result);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status) 
        {
            if (!Enum.IsDefined(typeof(TransactionStatus), status)) 
            {
                return BadRequest("Status doesn't exist. Ex.: Approved, Rejected, Failed, Done, Finished");
            }

            var result = await _service.GetTransactionsByStatus(status);

            return Ok(result);
        }

        [HttpGet("getbyperiod")]
        public async Task<IActionResult> GetByDate([FromBody]FilterDates filter) 
        {
            var result =  await _service.GetTransactionsByDatePeriod(filter);

            return Ok(result);
        }
    }
}