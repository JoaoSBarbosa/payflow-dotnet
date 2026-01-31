using Microsoft.AspNetCore.Mvc;
using payFlow.Application.Transactions.Interfaces;


namespace payFlow.Api.Controllers
{

    [ApiController]
    [Route("v1/transactions")]
    public class TransactionController(ILogger<TransactionController> logger, ITransactionService service)
        : ControllerBase
    {

        private readonly ILogger<TransactionController> _logger = logger;

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var transactions = await service.GetAllTransactionsAsync();
            return Ok(transactions);

        }

 
    }
}
