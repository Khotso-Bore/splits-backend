using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SplitsAPI.BLL.Services.IServices;
using SplitsAPI.Infrastructure.DTOs;

namespace SplitsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;

        public TransactionsController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction(AddTransactionDTO transactionDTO)
        {
            await _transactionsService.AddTransaction(transactionDTO);
            return Ok();
        }

        [HttpGet("GetPendingTransactions")]
        public async Task<IActionResult> GetPendingTransactions(Guid userId)
        {
            return Ok(await _transactionsService.GetPendingTransactions(userId));
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetTransactionsSummary(Guid userId)
        {
            return Ok(await _transactionsService.GetTransactionSummary(userId));
        }

        [HttpGet("GetDebtorTransactions")]
        public async Task<IActionResult> GetDebtorTransactions(GetTransactionDTO transactionDTO)
        {
            return Ok(await _transactionsService.GetDebtorTransactions(transactionDTO));
        }
    }
}
