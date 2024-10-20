using Microsoft.EntityFrameworkCore;
using SplitsAPI.BLL.Services.IServices;
using SplitsAPI.Domian.Data;
using SplitsAPI.Domian.Entities;
using SplitsAPI.Domian.Enums;
using SplitsAPI.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitsAPI.BLL.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly SplitsDbContext _splitsDbContext;

        public TransactionsService(SplitsDbContext splitsDbContext)
        {
            _splitsDbContext = splitsDbContext;
        }

        public async Task AddTransaction(AddTransactionDTO addTransactionDTO)
        {
            var debtor = await _splitsDbContext.Users.FirstOrDefaultAsync(x => x.Id.Equals(addTransactionDTO.DebtorId));

            if (debtor == null)
                return;

            var creditor = await _splitsDbContext.Users.FirstOrDefaultAsync(x => x.Id.Equals(addTransactionDTO.CreditorId));

            if (creditor == null)
                return;

            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                CreditorId = addTransactionDTO.CreditorId,
                DebtorId = addTransactionDTO.DebtorId,
                Category = (Category)addTransactionDTO.Category,
                Amount = addTransactionDTO.Amount,
                TransactionState = TransactionState.Pending,
                Date = DateTime.Now,
                Occassion = addTransactionDTO.Occassion,

            };

            await _splitsDbContext.Transactions.AddAsync(transaction);
            await _splitsDbContext.SaveChangesAsync();
        }

        public async Task<List<Transaction>> GetPendingTransactions(Guid userId)
        {
            var transactions = await _splitsDbContext.Transactions
                .Where(x =>
                x.CreditorId.Equals(userId)
                && x.TransactionState.Equals(TransactionState.Pending))
                .ToListAsync();

            return transactions;
        }

        public async Task<List<Transaction>> GetDebtorTransactions(GetTransactionDTO getTransactionDTO)
        {
            var transactions = await _splitsDbContext.Transactions
                .Where(x =>
            x.CreditorId.Equals(getTransactionDTO.CreditorId)
            && x.DebtorId.Equals(getTransactionDTO.DebtorId)
            && x.TransactionState == TransactionState.Accepted)
                .ToListAsync();

            return transactions;
        }

        public async Task<object> GetTransactionSummary(Guid userId)
        {
          var transactions = await _splitsDbContext.Transactions
                .Where(x => 
                x.CreditorId.Equals(userId))
                .Include(x => x.DebtorUser)
                .GroupBy(x => x.DebtorId)
                .Select(g => new
                {
                    DebtorId = g.Key,
                    DebtorName = g.FirstOrDefault().DebtorUser.UserName,
                    DebtorNumber = g.FirstOrDefault().DebtorUser.Number,
                    Transactions = g.ToList()

                })
                .ToListAsync();

            return transactions;
                
        }


    }
}
