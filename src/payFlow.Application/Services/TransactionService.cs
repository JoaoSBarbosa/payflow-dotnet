using payFlow.Application.DTOs.Transactions.Response;
using payFlow.Application.Interfaces;
using payFlow.Core.Enums;
using payFlow.Core.Factories;

namespace payFlow.Application.Services
{
    public class TransactionService : ITransactionService
    {
        public Task<IEnumerable<TransactionResponse>> GetAllTransactionsAsync()
        {
            return Task.FromResult<IEnumerable<TransactionResponse>>(new List<TransactionResponse>());
        }

        public async Task ProcessTransactionAsync(int userId, string title, decimal amount, ETransactionType type, long categoryId)
        {

            // recupera o saldo atual do usuário
            //var currentBalance = await _balanceRepository.GetBalanceByUserId(userId);

            var currentBalance = 1000m;
            var strategy = TransactionStrategyFactory.Create(type);

            strategy.Apply(currentBalance, amount);
        }
    }
}
