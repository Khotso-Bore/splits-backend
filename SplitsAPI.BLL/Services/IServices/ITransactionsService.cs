using SplitsAPI.Domian.Entities;
using SplitsAPI.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitsAPI.BLL.Services.IServices
{
    public interface ITransactionsService
    {
        Task AddTransaction(AddTransactionDTO addTransactionDTO);
        Task<List<Transaction>> GetDebtorTransactions(GetTransactionDTO getTransactionDTO);
        Task<List<Transaction>> GetPendingTransactions(Guid userId);
        Task<object> GetTransactionSummary(Guid userId);
    }
}
