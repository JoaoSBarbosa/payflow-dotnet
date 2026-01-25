using payFlow.Core.Enums;
using payFlow.Core.Factories;
using payFlow.Core.Interfaces;

namespace payFlow.Core.Services
{
    public class TransactionService : ITransactionService
    {
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
